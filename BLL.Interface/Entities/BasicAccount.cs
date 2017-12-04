namespace BLL.Interface.Entities
{
    public sealed class BasicAccount : BankAccount
    {
        #region Constructors

        public BasicAccount(string iban, int ownersId, decimal balance = 0, int bonusPoints = 0, bool isClosed = false) : base(iban, ownersId, balance, bonusPoints, isClosed)
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
