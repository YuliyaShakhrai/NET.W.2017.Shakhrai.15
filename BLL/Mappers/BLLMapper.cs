using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    internal static class BllEntityMapper
    {
        internal static BankAccountDTO ToBankAccountDTO(this BankAccount account) =>
            new BankAccountDTO(account.GetType().Name, account.Iban, account.OwnersId, account.Balance, account.BonusPoints, account.IsClosed)
            {
                AccountType = account.GetType().Name,
                IBAN = account.Iban,
                OwnersId = account.OwnersId,
                Balance = account.Balance,
                BonusPoints = account.BonusPoints,
                IsClosed = account.IsClosed
            };

        internal static BankAccount ToBankAccount(this BankAccountDTO accountDTO) =>
            (BankAccount)Activator.CreateInstance(
                GetBankAccountType(accountDTO.AccountType),
                accountDTO.IBAN,
                accountDTO.OwnersId,
                accountDTO.Balance,
                accountDTO.BonusPoints,
                accountDTO.IsClosed);

        private static Type GetBankAccountType(string type)
        {
            if (type.Contains("Gold"))
            {
                return typeof(GoldAccount);
            }

            if (type.Contains("Platinum"))
            {
                return typeof(PlatinumAccount);
            }

            return typeof(BasicAccount);
        }
    }
}
