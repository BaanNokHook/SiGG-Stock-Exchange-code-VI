﻿using StockExchange.Domain.Common;

namespace StockExchange.Domain
{
    public sealed class ConversionAmount : ValueObject<ConversionAmount>
    {
        public decimal BankConvertedAmountValue;

        public Currency CurrencyFrom { get; }
        public Currency CurrencyTo { get; }
        public decimal ConvertedAmountValue { get; }

        public ConversionAmount(Currency currencyFrom, Currency currencyTo, decimal convertedAmount)
        {
            CurrencyFrom = currencyFrom;
            CurrencyTo = currencyTo;
            ConvertedAmountValue = convertedAmount;
        }

        public override string ToString()
        {
            return $"{this.ConvertedAmountValue} {CurrencyTo}";
        }
    }
}