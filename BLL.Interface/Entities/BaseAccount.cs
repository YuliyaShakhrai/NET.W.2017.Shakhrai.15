using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public sealed class BaseAccount : BankAccount
    {
        #region Private fields

        #endregion

        #region Constructors

        public BaseAccount(string iban, string firstName, string lastName) : base(iban, firstName, lastName)
        {
        }

        public BaseAccount(string iban, string firstName, string lastName, decimal balance, long bonusPoints, bool isClosed) : base(iban, firstName, lastName, balance, bonusPoints, isClosed)
        {
        }

        #endregion

        #region Properties

        protected override int ReplenishBalanceCoeff => 3;

        protected override int ReplenishValueCoeff => 1;

        protected override int WithdrawBalanceCoeff => 2;

        protected override int WithdrawValueCoeff => 1;

        #endregion
    }
}
