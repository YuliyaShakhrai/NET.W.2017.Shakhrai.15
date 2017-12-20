using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;
using BLL.Mappers;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        #region Private fields

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new service instance with specified storage and IBAN generator.
        /// </summary>
        /// <param name="storage">Bank account's storage.</param>
        /// <param name="ibanGenerator">IBAN generator.</param>
        public AccountService(IRepository storage, IIBANGenerator ibanGenerator)
        {
            this.Storage = storage;
            this.IBANGenerator = ibanGenerator;
        }

        #endregion

        #region Properties

        /// <summary>
        /// IBAN generator.
        /// </summary>
        public IIBANGenerator IBANGenerator { get; set; }

        /// <summary>
        /// Bank account's storage.
        /// </summary>
        public IRepository Storage { get; set; }

        #endregion

        #region Interface implementation

        /// <summary>
        /// Closes an account with specified IBAN
        /// </summary>
        /// <param name="iban">IBAN of an account to close</param>
        public void CloseAccount(string iban)
        {
            throw new NotImplementedException();
        }

        public void Deposit(string iban, decimal amount)
        {
            throw new NotImplementedException();
        }

        public BankAccount GetAccountById(string iban)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BankAccount> GetAll()
        {
            throw new NotImplementedException();
        }

        public string OpenAccount(int ownersId, decimal balance, int bonusPoints, bool isClosed, AccountType accountType)
        {
            VerifyInput(ownersId, balance, bonusPoints);

            string accountIban = IBANGenerator.GenerateAccountNumber();

                var account = CreateAccount(accountIban, ownersId, balance, bonusPoints, isClosed, accountType);

                Storage.Add(account.ToBankAccountDTO());

                return accountIban;
        }

        public void Withdraw(string iban, decimal amount)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private methods

        private static BankAccount CreateAccount(string iban, int ownersId, decimal balance, int bonusPoints, bool isClosed, AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Gold:
                    return new GoldAccount(iban, ownersId, balance, bonusPoints, isClosed);
                case AccountType.Platinum:
                    return new PlatinumAccount(iban, ownersId, balance, bonusPoints, isClosed);
                case AccountType.Basic:
                default:
                    return new BasicAccount(iban, ownersId, balance, bonusPoints, isClosed);
            }
        }

        private static void VerifyInput(int ownersId, decimal balance, int bonusPoints)
        {
            if (ownersId <= 0)
            {
                throw new ArgumentException($"{nameof(ownersId)} is lesser or equal to zero.");
            }

            if (balance < 0)
            {
                throw new ArgumentException($"{nameof(balance)} must be greater or equal to zero.");
            }

            if (bonusPoints < 0)
            {
                throw new ArgumentException($"{nameof(bonusPoints)} must be greater or equal to zero zero.");
            }
        }

        #endregion
    }
}
