using System;

namespace DAL.Interface.DTO
{
    public class BankAccountDTO
    {
        /// <summary>
        /// Account type.
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        /// Gets account's IBAN.
        /// </summary>
        public string IBAN { get; set; }

        /// <summary>
        /// Gets Id of the account's owner.
        /// </summary>
        public int OwnersId { get; set; }

        /// <summary>
        /// Gets current balance of the account.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets current bonus points of the account.
        /// </summary>
        public int BonusPoints { get; set; }

        /// <summary>
        /// Gets a state of the account: is closed or not.
        /// </summary>
        public bool IsClosed { get; set; }

        public BankAccountDTO(string accountType, string iban, int ownersId, decimal balance, int bonusPoints, bool isClosed)
        {
            AccountType = accountType;
            IBAN = iban;
            OwnersId = ownersId;
            Balance = balance;
            BonusPoints = bonusPoints;
            IsClosed = isClosed;
        }
    }
}
