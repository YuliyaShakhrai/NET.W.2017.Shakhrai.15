namespace BLL.Interface.Entities
{
    public sealed class PlatinumAccount : BankAccount
    {
        #region Constructors

        public PlatinumAccount(string iban, int ownersId, decimal balance = 0, int bonusPoints = 0, bool isClosed = false) : base(iban, ownersId, balance, bonusPoints, isClosed)
        {
        }

        #endregion

        protected override int ReplenishBalanceCoeff => 10;

        protected override int ReplenishValueCoeff => 5;

        protected override int WithdrawBalanceCoeff => 1;

        protected override int WithdrawValueCoeff => 1;
    }
}
