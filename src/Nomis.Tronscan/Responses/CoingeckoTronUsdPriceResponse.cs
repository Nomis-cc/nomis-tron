using System.Text.Json.Serialization;

using Nomis.Coingecko.Interfaces.Models;

namespace Nomis.Tronscan.Responses
{
    /// <summary>
    /// Coingecko Tron USD price response.
    /// </summary>
    public class CoingeckoTronUsdPriceResponse :
        ICoingeckoUsdPriceResponse
    {
        /// <inheritdoc cref="CoingeckoUsdPriceData"/>
        [JsonPropertyName("tron")]
        public CoingeckoUsdPriceData? Data { get; set; }
    }
}