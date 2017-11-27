using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IRepository
    {
        /// <summary>
        /// Adds the specified bankAccountDTO to the repository.
        /// </summary>
        /// <param name="bankAccountDTO">Bank account.</param>
        void Add(BankAccountDTO bankAccountDTO);

        /// <summary>
        /// Updates the specified bankAccountDTO in the repository.
        /// </summary>
        /// <param name="bankAccountDTO">Bank account.</param>
        void Update(BankAccountDTO bankAccountDTO);

        /// <summary>
        /// Gets all bank accounts.
        /// </summary>
        /// <returns>Enumeration of all bank accounts.</returns>
        IEnumerable<BankAccountDTO> GetAll();

        /// <summary>
        /// Gets the account with the specified <paramref name="IBAN"/>. 
        /// </summary>
        /// <param name="iban">Account's IBAN.</param>
        /// <returns>Specified bank account. If account not found returns null.</returns>
        BankAccountDTO GetAccountById(string iban);
    }
}
