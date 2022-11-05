using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nomis.Blockchain.Abstractions.Settings;
using Nomis.Tronscan.Interfaces;
using Nomis.Tronscan.Interfaces.Settings;
using Nomis.Utils.Extensions;

namespace Nomis.Tronscan.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extension methods.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add Tronscan service.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="configuration"><see cref="IConfiguration"/>.</param>
        /// <returns>Returns <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddTronscanService(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSettings<TronscanSettings>(configuration);
            var settings = configuration.GetSettings<ApiVisibilitySettings>();
            if (settings.TronAPIEnabled)
            {
                return services
                    .AddTransient<ITronscanClient, TronscanClient>()
                    .AddTransientInfrastructureService<ITronscanService, TronscanService>();
            }
            else
            {
                return services;
            }
        }
    }
}