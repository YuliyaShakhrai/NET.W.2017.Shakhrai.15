namespace BLL.Interface.Entities
{
    public sealed class PlatinumAccount : BankAccount
    {
        #region Constructors

        public PlatinumAccount(string iban, string firstName, string lastName, decimal balance = 0, long bonusPoints = 0, bool isClosed = false) : base(iban, firstName, lastName, balance, bonusPoints, isClosed)
        {
        }

        #endregion

        protected override int ReplenishBalanceCoeff => 10;

        protected override int ReplenishValueCoeff => 5;

        protected override int WithdrawBalanceCoeff => 1;

        protected override int WithdrawValueCoeff => 1;
    }
}
