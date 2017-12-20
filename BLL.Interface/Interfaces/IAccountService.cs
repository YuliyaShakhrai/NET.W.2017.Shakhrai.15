using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Opens a bank account of specified type with input or default balance and bonus points.
        /// </summary>
        /// <param name="firstName">Owner's ID.</param>
        /// <param name="balance">Account balance.</param>
        /// <param name="bonusPoints">Account bonus points.</param>
        /// <param name="isClosed">Account status.</param>
        /// <param name="accountType">Type of the bank account.</param>
        /// <returns>New account's IBAN.</returns>
        string OpenAccount(int ownersId, decimal balance, int bonusPoints, bool isClosed, AccountType accountType);

        /// <summary>
        /// Closes the bank account with the specified IBAN and disables all the money operations.
        /// </summary>
        /// <param name="iban">Account's IBAN.</param>
        void CloseAccount(string iban);

        /// <summary>
        /// Adds the amount of money equal to amount to the bank account with specified IBAN.
        /// </summary>
        /// <param name="iban">Account's IBAN.</param>
        /// <param name="amount">Amount of money to deposit.</param>
        void Deposit(string iban, decimal amount);

        /// <summary>
        /// Withdraws the amount of money equal to amount from the bank account with specified IBAN.
        /// </summary>
        /// <param name="iban">Account's IBAN.</param>
        /// <param name="amount">Amount of money to withdraw.</param>
        void Withdraw(string iban, decimal amount);

        /// <summary>
        /// Gets all bank accounts.
        /// </summary>
        /// <returns>Enumeration of all bank accounts.</returns>
        IEnumerable<BankAccount> GetAll();

        /// <summary>
        /// Gets the account with the specified IBAN. 
        /// </summary>
        /// <param name="iban">Account's IBAN.</param>
        /// <returns>Specified bank account. If account not found returns null.</returns>
        BankAccount GetAccountById(string iban);
    }
}
