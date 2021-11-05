using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Application.Exceptions;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;
using MerchandiseService.Domain.AggregationModels.MerchInquiryAggregate;
using MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using static MerchandiseService.Application.Commands.MerchItemAggregate.IssueMerchItemCommandResult;

namespace MerchandiseService.Application.Commands.MerchItemAggregate
{
    public class IssueMerchItemCommandHandler : IRequestHandler<IssueMerchCommand, IssueMerchItemCommandResult>
    {
        private readonly IClock _clock;
        private readonly IIssuedMerchRepository _issuedMerchRepository;
        private readonly IMerchInquiryRepository _merchInquiryRepository;
        private readonly IMerchItemRepository _merchItemRepository;

        public IssueMerchItemCommandHandler(
            IMerchItemRepository merchItemRepository,
            IIssuedMerchRepository issuedMerchRepository,
            IMerchInquiryRepository merchInquiryRepository,
            IClock clock
        )
        {
            _merchItemRepository = merchItemRepository;
            _issuedMerchRepository = issuedMerchRepository;
            _merchInquiryRepository = merchInquiryRepository;
            _clock = clock;
        }

        public async Task<IssueMerchItemCommandResult> Handle(
            IssueMerchCommand request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var sku = new Sku(request.Sku);

            /*
             * Синхронизация для каждого мерча, чтобы обработка одного и того же Sku не проходила одновременно,
             * иначе могут быть ошибки с выдачей (выдано больше, чем в наличии)
             */
            using var locking = await AsyncLockMutexProducer<Sku>.Get(sku).LockAsync(cancellationToken);

            var merchItem = await _merchItemRepository.FindAsync(sku, cancellationToken);
            if (merchItem is null) throw new AppException($"Not found merch with sku {sku}");

            var employeeId = new EmployeeId(new Guid(request.EmployeeId));

            var issuedMerch = await _issuedMerchRepository.FindAsync(sku, employeeId, cancellationToken);
            if (issuedMerch is not null) return AlreadyIssued;
            // TODO Проверяется наличие данного мерча на складе через запрос к stock-api,
            // stock-api будет готов к следующему ДЗ: https://route256.slack.com/archives/C02FF0SQF0U/p1635879494054600?thread_ts=1635602103.039100&cid=C02FF0SQF0U
            // пока считаем, что мерч есть в наличии.

            var issueQuantity = new Quantity(request.Quantity);
            if (merchItem.CanBeIssued(issueQuantity))
            {
                merchItem = merchItem with { Quantity = merchItem.Quantity - issueQuantity };
                await Task.WhenAll(
                    UpdateMerch(merchItem, cancellationToken),
                    SaveIssuedMerch(sku, issueQuantity, employeeId, cancellationToken)
                    //TODO зарезервировать мерч в stock-api
                );
                return Issued;
            }

            await AddMerchInquiry(sku, issueQuantity, employeeId, cancellationToken);
            //TODO Обработка нотификейшена о появлении мерча на остатках и отправка уведомления (куда?)
            return Inquiried;
        }

        private async Task AddMerchInquiry(
            Sku sku,
            Quantity quantity,
            EmployeeId employeeId,
            CancellationToken cancellationToken)
        {
            await _merchInquiryRepository.AddAsync(new MerchInquiry(
                Guid.NewGuid(),
                sku,
                quantity,
                employeeId,
                _clock.GetCurrentTimeUtc())
            );
            await _merchInquiryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        private async Task SaveIssuedMerch(Sku sku, Quantity quantity,
            EmployeeId employeeId, CancellationToken cancellationToken)
        {
            await _issuedMerchRepository.AddAsync(new IssuedMerch(
                    Guid.NewGuid(),
                    sku,
                    quantity,
                    employeeId,
                    _clock.GetCurrentTimeUtc()
                ), cancellationToken
            );
            await _issuedMerchRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        private async Task UpdateMerch(MerchItem merchItem, CancellationToken cancellationToken)
        {
            await _merchItemRepository.UpdateAsync(merchItem, cancellationToken);
            await _merchItemRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}