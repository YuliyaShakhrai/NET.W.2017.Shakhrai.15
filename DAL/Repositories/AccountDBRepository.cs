using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    public sealed class AccountDBRepository : IRepository
    {
        public void Add(BankAccountDTO bankAccountDTO)
        {
            if (ReferenceEquals(bankAccountDTO, null))
            {
                throw new ArgumentNullException($"{nameof(bankAccountDTO)} is null.");
            }

            using (var context = new AccountsDBEntities())
            {
                context.Accounts.Add(new Account
                {
                    Balance = bankAccountDTO.Balance,
                    BonusPoints = bankAccountDTO.BonusPoints,
                    AccountIBAN = bankAccountDTO.IBAN,
                    OwnerId = bankAccountDTO.OwnersId,
                    AccountTypeId = bankAccountDTO.AccountType
                });
                context.SaveChanges();
            }
        }

        public BankAccountDTO GetAccountById(string iban)
        {
            if (string.IsNullOrEmpty(iban))
            {
                throw new ArgumentNullException($"{nameof(iban)} is null or empty.");
            }

            if (iban.Length != 28)
            {
                throw new ArgumentException($"{nameof(iban)} length is not 28.");
            }

            Account account;
            using (var context = new AccountsDBEntities())
            {
                account = context.Accounts.Find(iban);
            }

            return new BankAccountDTO(
                account.AccountType.AccountTypeId,
                account.AccountIBAN,
                account.OwnerId,
                account.Balance,
                account.BonusPoints,
                account.IsClosed);
        }

        public IEnumerable<BankAccountDTO> GetAll()
        {
            var accounts = new List<BankAccountDTO>();
            //TODO: GetAll()
            return accounts;
        }

        public void Update(BankAccountDTO bankAccountDTO)
        {
            Account account;
            using (var context = new AccountsDBEntities())
            {
                account = context.Accounts.Find(bankAccountDTO.IBAN);
                account.AccountTypeId = bankAccountDTO.AccountType;
                account.Balance = bankAccountDTO.Balance;
                account.BonusPoints = bankAccountDTO.BonusPoints;
                account.OwnerId = bankAccountDTO.OwnersId;
                context.SaveChanges();
            }
        }
    }
}
