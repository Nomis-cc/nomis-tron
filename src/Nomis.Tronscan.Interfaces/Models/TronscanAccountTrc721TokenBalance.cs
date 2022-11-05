﻿using System.Text.Json.Serialization;

namespace Nomis.Tronscan.Interfaces.Models
{
    /// <summary>
    /// Tronscan account TRC721 token balance data.
    /// </summary>
    public class TronscanAccountTrc721TokenBalance :
        ITronscanAccountBalanceData
    {
        /// <summary>
        /// The token id.
        /// </summary>
        [JsonPropertyName("tokenId")]
        public string? TokenId { get; set; }

        /// <summary>
        /// The token balance.
        /// </summary>
        [JsonPropertyName("balance")]
        public string? Balance { get; set; }

        /// <summary>
        /// The token name.
        /// </summary>
        [JsonPropertyName("tokenName")]
        public string? TokenName { get; set; }

        /// <summary>
        /// The token abbr.
        /// </summary>
        [JsonPropertyName("tokenAbbr")]
        public string? TokenAbbr { get; set; }

        /// <summary>
        /// The token decimal.
        /// </summary>
        [JsonPropertyName("tokenDecimal")]
        public int TokenDecimal { get; set; }

        /// <summary>
        /// The token can show.
        /// </summary>
        [JsonPropertyName("tokenCanShow")]
        public int TokenCanShow { get; set; }

        /// <summary>
        /// The token type.
        /// </summary>
        [JsonPropertyName("tokenType")]
        public string? TokenType { get; set; }

        /// <summary>
        /// The token logo.
        /// </summary>
        [JsonPropertyName("tokenLogo")]
        public string? TokenLogo { get; set; }

        /// <summary>
        /// VIP.
        /// </summary>
        [JsonPropertyName("vip")]
        public bool Vip { get; set; }

        /// <summary>
        /// The token holders number.
        /// </summary>
        [JsonPropertyName("nrOfTokenHolders")]
        public long NumberOfTokenHolders { get; set; }

        /// <summary>
        /// The token transfer count.
        /// </summary>
        [JsonPropertyName("transferCount")]
        public long TransferCount { get; set; }
    }
}