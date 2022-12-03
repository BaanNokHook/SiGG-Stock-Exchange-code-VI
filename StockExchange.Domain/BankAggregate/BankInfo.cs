﻿using StockExchange.Domain.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchange.Domain
{
    public class BankInfo : ValueObject<BankInfo>
    {
        private Money balance;
        private object moneyCollection;

        public BankInfo(Money balance, IValueObjectCollection<Money> otherCurrencies)
        {
            Balance = balance;
            OtherCurrencies = otherCurrencies;
        }

        public BankInfo(Money balance, object moneyCollection)
        {
            this.balance = balance;
            this.moneyCollection = moneyCollection;
        }

        public Money Balance { get; }
        public IValueObjectCollection<Money> OtherCurrencies { get; }

        public override string ToString()
        {
            var sb = new StringBuilder($"Основной баланс кошелька: {this.Balance.ToString()}.");
            sb.Append($" Баланс кошелька в других валютах:");
            var array = OtherCurrencies.ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                var money = array[i];
                if (money.SelectedCurrency == Balance.SelectedCurrency)//do not convert to the same currencies - transfer the check to the account
                {
                    continue;
                }

                if (i != array.Length - 1)
                {
                    sb.Append($" {money.ToString()},");
                }
                else
                {
                    sb.Append($" {money.ToString()}.");
                }
            }
            return sb.ToString();
        }

        private IList<Money> DuplicateCurrencyPolicy(Money balance, IEnumerable<Money> otherCurrencies)
        {
            return otherCurrencies.Where(curr => curr.SelectedCurrency != balance.SelectedCurrency).ToList();
        }
    }
}