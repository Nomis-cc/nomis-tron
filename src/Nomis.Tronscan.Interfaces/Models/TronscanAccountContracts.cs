using System.Text.Json.Serialization;

namespace Nomis.Tronscan.Interfaces.Models
{
    /// <summary>
    /// Tronscan account contracts data.
    /// </summary>
    public class TronscanAccountContracts
    {
        /// <summary>
        /// Total count.
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }

        /// <summary>
        /// The list of contracts.
        /// </summary>
        [JsonPropertyName("data")]
        public List<TronscanAccountContract>? Data { get; set; } = new();
    }
}