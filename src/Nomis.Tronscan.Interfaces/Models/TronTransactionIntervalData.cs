﻿using System.Numerics;
using System.Text.Json.Serialization;

using Nomis.Blockchain.Abstractions.Models;
using Nomis.Tronscan.Interfaces.Extensions;

namespace Nomis.Tronscan.Interfaces.Models
{
    /// <inheritdoc cref="ITransactionIntervalData"/>
    public class TronTransactionIntervalData :
        ITransactionIntervalData
    {
        /// <inheritdoc />
        public DateTime StartDate { get; set; }

        /// <inheritdoc />
        public DateTime EndDate { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public BigInteger AmountSum { get; set; }

        /// <inheritdoc cref="ITransactionIntervalData.AmountSum"/>
        public decimal AmountSumValue => AmountSum.ToTrx();

        /// <inheritdoc />
        [JsonIgnore]
        public BigInteger AmountOutSum { get; set; }

        /// <inheritdoc cref="ITransactionIntervalData.AmountOutSum"/>
        public decimal AmountOutSumValue => AmountOutSum.ToTrx();

        /// <inheritdoc />
        [JsonIgnore]
        public BigInteger AmountInSum { get; set; }

        /// <inheritdoc cref="ITransactionIntervalData.AmountInSum"/>
        public decimal AmountInSumValue => AmountInSum.ToTrx();

        /// <inheritdoc />
        public int Count { get; set; }
    }
}