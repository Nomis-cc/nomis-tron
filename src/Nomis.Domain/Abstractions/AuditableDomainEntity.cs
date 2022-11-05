﻿using Nomis.Domain.Contracts;
using Nomis.Utils.Contracts.Deleting;

namespace Nomis.Domain.Abstractions
{
    /// <summary>
    /// Auditable domain entity.
    /// </summary>
    /// <typeparam name="TEntityId">The auditable entity identifier type.</typeparam>
    public abstract class AuditableDomainEntity<TEntityId> :
        DomainEntity<TEntityId>,
        IAuditableEntity<TEntityId>,
        ISoftDelete
    {
        /// <inheritdoc/>
        public Guid CreatedBy { get; set; }

        /// <inheritdoc/>
        public DateTime CreatedOn { get; set; }

        /// <inheritdoc/>
        public Guid LastModifiedBy { get; set; }

        /// <inheritdoc/>
        public DateTime? LastModifiedOn { get; set; }

        /// <inheritdoc/>
        public DateTime? DeletedOn { get; set; }

        /// <inheritdoc/>
        public Guid? DeletedBy { get; set; }
    }

    /// <inheritdoc/>
    public abstract class AuditableDomainEntity :
        AuditableDomainEntity<Guid>
    {
        /// <inheritdoc/>
        public override Guid GenerateNewId()
        {
            return Guid.NewGuid();
        }
    }
}