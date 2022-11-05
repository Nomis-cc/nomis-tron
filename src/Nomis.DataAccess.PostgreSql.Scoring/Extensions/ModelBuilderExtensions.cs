﻿using Microsoft.EntityFrameworkCore;
using Nomis.DataAccess.PostgreSql.Scoring.Persistence.Configurations;

namespace Nomis.DataAccess.PostgreSql.Scoring.Extensions
{
    /// <summary>
    /// <see cref="ModelBuilder"/> extension methods.
    /// </summary>
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Apply scoring-related data access context configuration.
        /// </summary>
        /// <param name="builder"><see cref="ModelBuilder"/>.</param>
        public static void ApplyScoringConfiguration(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ScoringConfiguration());
        }
    }
}