namespace BLL.Interface.Entities
{
    public sealed class BaseAccount : BankAccount
    {
        #region Constructors

        public BaseAccount(string iban, string firstName, string lastName, decimal balance = 0, long bonusPoints = 0, bool isClosed = false) : base(iban, firstName, lastName, balance, bonusPoints, isClosed)
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
