using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Nomis.Tronscan.Interfaces.Models
{
    /// <summary>
    /// Tronscan account internal transactions.
    /// </summary>
    public class TronscanAccountInternalTransactions :
        ITronscanTransferList<TronscanAccountInternalTransaction>
    {
        /// <summary>
        /// Total transaction count.
        /// </summary>
        [JsonPropertyName("rangeTotal")]
        public long RangeTotal { get; set; }

        /// <summary>
        /// Total transaction count for this page.
        /// </summary>
        [JsonPropertyName("total")]
        public long Total { get; set; }

        /// <summary>
        /// List of transactions.
        /// </summary>
        [JsonPropertyName("data")]
        [DataMember(EmitDefaultValue = true)]
        public List<TronscanAccountInternalTransaction>? Data { get; set; } = new();
    }
}