using System.Collections.Generic;
using MediatR;

namespace MerchandiseService.Domain.Models
{
    public abstract record Entity
    {
        private List<INotification>? _domainEvents;

        public IReadOnlyCollection<INotification> DomainEvents
            => _domainEvents?.AsReadOnly() ?? new List<INotification>().AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            if (_domainEvents == null) _domainEvents = new List<INotification>();

            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}