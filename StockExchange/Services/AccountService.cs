using StockExchange.API.ViewModels;
using StockExchange.Domain;
using StockExchange.Domain.Common;
using StockExchange.Domain.UserAggregate;
using System;
using System.Threading.Tasks;

namespace StockExchange.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly ICurrencyService currencyService;
        private readonly IUserService userService;

        public AccountService(IUserService userService, ICurrencyService currencyService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.currencyService = currencyService ?? throw new ArgumentNullException(nameof(currencyService)); ;
        }

        public ResponseVm ConvertToCurrency(long userId, string targetCurrencyStr)
        {
            
            var user = userService.GetById(userId);
            var targetCurrency = Currency.Parse(targetCurrencyStr);
            var fromCurrency = user.Account.Balance.SelectedCurrency;
            if (targetCurrency == fromCurrency)
            {
                throw new ArgumentException("Cannot convert to the same currency");
            }

            var conversionAmount = currencyService.GetConversionAmount(user.Account.Balance.SelectedCurrency, targetCurrency, user.Account.Balance.Amount);
            user.Account.ConvertToCurrency(targetCurrency, conversionAmount);

            var responseMsg = $"Currency conversion from c {fromCurrency} в {targetCurrency.ToString()}. Balance: {user.Account.Balance.ToString()}.";

            return CreateResponseVm(user.Account.Balance.Amount, user.Account.Balance.SelectedCurrency, responseMsg);
        }

        public ResponseVm Deposit(long userId, decimal amount)
        {

            var user = userService.GetById(userId);
            user.Account.Deposit(new Money(amount, user.Account.Balance.SelectedCurrency));

            var responseMsg = $"Wallet topped up on: {amount} {user.Account.Balance.SelectedCurrency}. Balance: {user.Account.Balance.ToString()}.";

            return CreateResponseVm(user.Account.Balance.Amount, user.Account.Balance.SelectedCurrency, responseMsg);
        }

        public ResponseVm GetAccountInfo(long userId)
        {
           
            var user = userService.GetById(userId);
            var moneyCollection = GetConvertedMoneyCollection(user.Account);
            var responseMsg = new AccountInfo(user.Account.Balance, moneyCollection).ToString();

            return CreateResponseVm(user.Account.Balance.Amount, user.Account.Balance.SelectedCurrency, responseMsg);
        }

        public ResponseVm Withdraw(long userId, decimal amount)
        {
     
            var user = userService.GetById(userId);
            user.Account.Withdraw(new Money(amount, user.Account.Balance.SelectedCurrency));
            var responseMsg = $"Withdrawing money for: {amount} {user.Account.Balance.SelectedCurrency}. Balance: {user.Account.Balance.ToString()}.";

            return CreateResponseVm(user.Account.Balance.Amount, user.Account.Balance.SelectedCurrency, responseMsg);
        }

        private ResponseVm CreateResponseVm(decimal accountBalance, Currency accountCurrency, string message)
        {
            return new ResponseVm() { Amount = accountBalance, Currency = accountCurrency, Message = message };
        }

        private IValueObjectCollection<Money> GetConvertedMoneyCollection(Bank account)
        {
            var moneyCollection = new ValueObjectCollection<Money>();
            foreach (var targetCurrency in account.Currencies)
            {
                //ToDo Domain Policy Validation Pattern
                if (targetCurrency == account.Balance.SelectedCurrency)
                {
                    continue;
                }
                var conversionResult = currencyService.GetConversionAmount(account.Balance.SelectedCurrency, targetCurrency, account.Balance.Amount);
                moneyCollection = (ValueObjectCollection<Money>)moneyCollection.AddImmutable(new Money(conversionResult.ConvertedAmountValue, conversionResult.CurrencyTo));
            }
            return moneyCollection;           
        }
    }
}