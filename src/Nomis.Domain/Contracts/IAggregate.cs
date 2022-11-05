﻿using Nomis.Utils.Contracts.Common;
using Nomis.Utils.Contracts.Properties;

namespace Nomis.Domain.Contracts
{
    /// <inheritdoc cref="IAggregate"/>
    /// <typeparam name="TAggregateId">The aggregate identifier type.</typeparam>
    public interface IAggregate<out TAggregateId> :
        IAggregate,
        IEntity<TAggregateId>
    {
        /// <summary>
        /// Aggregate identifier.
        /// </summary>
        public new TAggregateId Id { get; }
    }

    /// <summary>
    /// Aggregate.
    /// </summary>
    public interface IAggregate :
        IHasVersion
    {
        /// <summary>
        /// Aggregate current version.
        /// </summary>
        new int Version { get; }

        /// <summary>
        /// Increment aggregate version by one.
        /// </summary>
        void IncrementVersion();
    }
}