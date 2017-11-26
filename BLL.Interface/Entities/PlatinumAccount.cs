using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public sealed class PlatinumAccount : BankAccount
    {
        #region Constructors

        public PlatinumAccount(string iban, string firstName, string lastName) : base(iban, firstName, lastName)
        {
        }

        public PlatinumAccount(string iban, string firstName, string lastName, decimal balance, long bonusPoints, bool isClosed) : base(iban, firstName, lastName, balance, bonusPoints, isClosed)
        {
        }

        #endregion

        protected override int ReplenishBalanceCoeff => throw new NotImplementedException();

        protected override int ReplenishValueCoeff => throw new NotImplementedException();

        protected override int WithdrawBalanceCoeff => throw new NotImplementedException();

        protected override int WithdrawValueCoeff => throw new NotImplementedException();
    }
}
