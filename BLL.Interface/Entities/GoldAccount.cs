namespace BLL.Interface.Entities
{
    public sealed class GoldAccount : BankAccount
    {
        #region Constructors

        public GoldAccount(string iban, string firstName, string lastName, decimal balance = 0, long bonusPoints = 0, bool isClosed = false) : base(iban, firstName, lastName, balance, bonusPoints, isClosed)
        {
        }

        #endregion

        protected override int ReplenishBalanceCoeff => 5;

        protected override int ReplenishValueCoeff => 2;

        protected override int WithdrawBalanceCoeff => 2;

        protected override int WithdrawValueCoeff => 1;
    }
}
