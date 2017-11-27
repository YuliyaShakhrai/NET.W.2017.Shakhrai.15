using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;

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

        public string OpenAccount(string firstName, string lastName, AccountType accountType)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(string iban, decimal amount)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
