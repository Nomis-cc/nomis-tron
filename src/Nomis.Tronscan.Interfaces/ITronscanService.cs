using Nomis.Tronscan.Interfaces.Models;
using Nomis.Utils.Contracts.Services;
using Nomis.Utils.Wrapper;

namespace Nomis.Tronscan.Interfaces
{
    /// <summary>
    /// Tronscan service.
    /// </summary>
    public interface ITronscanService :
        IInfrastructureService
    {
        /// <summary>
        /// Client for interacting with Tronscan API.
        /// </summary>
        public ITronscanClient Client { get; }

        /// <summary>
        /// Get tron wallet stats by address.
        /// </summary>
        /// <param name="address">Tron wallet address.</param>
        /// <returns>Returns <see cref="TronWalletScore"/> result.</returns>
        public Task<Result<TronWalletScore>> GetWalletStatsAsync(string address);
    }
}