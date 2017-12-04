using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    public class AccountBinaryRepository : IRepository
    {
        #region Private fields

        /// <summary>
        /// Path to a binary file.
        /// </summary>
        private string path;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance to work with file on path. If file not exist creates it.
        /// </summary>
        /// <param name="path">path to a binary file</param>
        public AccountBinaryRepository(string path)
        {
            this.path = path;
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        #endregion

        #region Interface implementation

        public void Add(BankAccountDTO bankAccountDTO)
        {
            if (bankAccountDTO == null)
            {
                throw new ArgumentNullException($"{nameof(bankAccountDTO)} is null.");
            }

            using (var stream = new FileStream(path, FileMode.Append))
            {
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write(bankAccountDTO.IBAN);
                    writer.Write(bankAccountDTO.OwnersId);
                    writer.Write(bankAccountDTO.Balance);
                    writer.Write(bankAccountDTO.BonusPoints);
                    writer.Write(bankAccountDTO.AccountType);
                    writer.Write(bankAccountDTO.IsClosed);
                }
            }
        }

        /// <summary>
        /// Gets the account from a file by IBAN.
        /// </summary>
        /// <param name="iban">Account's IBAN.</param>
        /// <returns>Bank account with specified IBAN or null if it not found.</returns>
        public BankAccountDTO GetAccountById(string iban)
        {
            if (string.IsNullOrWhiteSpace(iban))
            {
                throw new ArgumentNullException($"{nameof(iban)} is null or empty.");
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all accounts DTO from storage.
        /// </summary>
        /// <returns>IEnumerable instance of accounts.</returns>
        public IEnumerable<BankAccountDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an account info in storage.
        /// </summary>
        /// <param name="account">Account DTO to update.</param>
        public void Update(BankAccountDTO bankAccountDTO)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
