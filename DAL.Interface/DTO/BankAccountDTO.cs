using System;

namespace DAL.Interface.DTO
{
    public class BankAccountDTO
    {
        /// <summary>
        /// Account type.
        /// </summary>
        public Type AccountType { get; set; }

        /// <summary>
        /// Gets account's IBAN.
        /// </summary>
        public string IBAN { get; set; }

        /// <summary>
        /// Gets first name of the account's owner.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets last name of the account's owner.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets current balance of the account.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets current bonus points of the account.
        /// </summary>
        public long BonusPoints { get; set; }

        /// <summary>
        /// Gets a state of the account: is closed or not.
        /// </summary>
        public bool IsClosed { get; set; }
    }
}
