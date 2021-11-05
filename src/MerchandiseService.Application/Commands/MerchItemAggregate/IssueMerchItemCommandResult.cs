namespace MerchandiseService.Application.Commands.MerchItemAggregate
{
    public enum IssueMerchItemCommandResult
    {
        /// <summary>
        /// Мерч успешно выдан
        /// </summary>
        Issued,

        /// <summary>
        /// Мереч поставлен в очередь на выдачу.
        /// Как только он появится в достаточном количестве, будет отправлено увдомление.
        /// </summary>
        Inquiried,

        /// <summary>
        /// Мерч не выдан, т.к. такой мерч уже выдавался этому сотруднику.
        /// </summary>
        AlreadyIssued,
    }
}