﻿namespace Nomis.Domain.Contracts
{
    /// <summary>
    /// Generates domain events.
    /// </summary>
    public interface IGeneratesDomainEvents
    {
        /// <summary>
        /// Collection of domain events.
        /// </summary>
        public IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        /// <summary>
        ///Add domain event.
        /// </summary>
        /// <param name="domainEvent">Added domain event.</param>
        public void AddDomainEvent(IDomainEvent domainEvent);

        /// <summary>
        /// Delete domain event.
        /// </summary>
        /// <param name="domainEvent">Deleted domain event.</param>
        public void RemoveDomainEvent(IDomainEvent domainEvent);

        /// <summary>
        /// Clear the collection of domain events.
        /// </summary>
        public void ClearDomainEvents();
    }
}