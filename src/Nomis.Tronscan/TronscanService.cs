using System.Text.Json;

using Nomis.Tronscan.Calculators;
using Nomis.Tronscan.Interfaces;
using Nomis.Tronscan.Interfaces.Models;
using Nomis.Tronscan.Responses;
using Nomis.Coingecko.Interfaces;
using Nomis.Domain.Scoring.Entities;
using Nomis.ScoringService.Interfaces;
using Nomis.Utils.Contracts.Services;
using Nomis.Utils.Enums;
using Nomis.Utils.Wrapper;

namespace Nomis.Tronscan
{
    /// <inheritdoc cref="ITronscanService"/>
    internal sealed class TronscanService :
        ITronscanService,
        ITransientService
    {
        private readonly ICoingeckoService _coingeckoService;
        private readonly IScoringService _scoringService;

        /// <summary>
        /// Initialize <see cref="TronscanService"/>.
        /// </summary>
        /// <param name="client"><see cref="ITronscanClient"/>.</param>
        /// <param name="coingeckoService"><see cref="ICoingeckoService"/>.</param>
        /// <param name="scoringService"><see cref="IScoringService"/>.</param>
        public TronscanService(
            ITronscanClient client,
            ICoingeckoService coingeckoService,
            IScoringService scoringService)
        {
            _coingeckoService = coingeckoService;
            _scoringService = scoringService;
            Client = client;
        }

        /// <inheritdoc/>
        public ITronscanClient Client { get; }

        /// <inheritdoc/>
        public async Task<Result<TronWalletScore>> GetWalletStatsAsync(string address)
        {
            var accountData = await Client.GetBalanceAsync(address);
            var balance = accountData.Tokens?.Sum(x => x.Amount) ?? accountData.Balance;
            var usdBalance = await _coingeckoService.GetUsdBalanceAsync<CoingeckoTronUsdPriceResponse>(balance, "tron");
            var contractsData = await Client.GetContractsAsync(address);
            var transactions = (await Client.GetTransactionsAsync<TronscanAccountNormalTransactions, TronscanAccountNormalTransaction>(address)).ToList();
            var internalTransactions = (await Client.GetTransactionsAsync<TronscanAccountInternalTransactions, TronscanAccountInternalTransaction>(address)).ToList();
            var transfers = await Client.GetTransactionsAsync<TronscanAccountTransfers, TronscanAccountTransfer>(address);
            var tokens = transfers.Where(x => x.TokenInfo?.TokenType?.Equals("trc721", StringComparison.OrdinalIgnoreCase) == true).ToList();

            var walletStats = new TronStatCalculator(
                    address,
                    accountData,
                    balance,
                    usdBalance,
                    transactions,
                    internalTransactions,
                    tokens,
                    accountData.Trc20Balances ?? new(),
                    contractsData)
                .GetStats();

            var score = walletStats.GetScore();
            var scoringData = new ScoringData(address, address, BlockchainNetwork.Tron, score,
                JsonSerializer.Serialize(walletStats));
            await _scoringService.SaveScoringDataToDatabaseAsync(scoringData);

            return await Result<TronWalletScore>.SuccessAsync(new()
            {
                Address = address,
                Stats = walletStats,
                Score = score
            }, "Got tron wallet score.");
        }
    }
}