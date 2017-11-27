using System;

namespace BLL.Interface.Entities
{
    public abstract class BankAccount
    {
        #region Private fields

        private string _iban;
        private string _firstName;
        private string _lastName;
        private decimal _balance;
        private long _bonusPoints;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates bank account.
        /// </summary>
        /// <param name="iban">Account's IBAN.</param>
        /// <param name="firstName">First name of the account's owner.</param>
        /// <param name="lastName">Last name of the account's owner.</param>
        /// <param name="balance">Account balance. Default is 0.</param>
        /// <param name="bonusPoints">Account bonus points. Default is 0.</param>
        /// <param name="isClosed">Account's state. Default isClosed = false.</param>
        public BankAccount(string iban, string firstName, string lastName, decimal balance = 0, long bonusPoints = 0, bool isClosed = false)
        {
            VerifyInput(iban, firstName, lastName, balance, bonusPoints);

            Iban = iban;
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
            BonusPoints = bonusPoints;
            IsClosed = isClosed;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Account's identifier number.
        /// </summary>
        /// <exception cref="ArgumentNullException">Value is null.</exception>
        public string Iban
        {
            get
            {
                return _iban;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"{nameof(Iban)} cannot be null.");
                }

                _iban = value;
            }
        }

        /// <summary>
        /// First name of the account's owner.
        /// </summary>
        /// <exception cref="ArgumentNullException">Value is null.</exception>
        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"{nameof(FirstName)} cannot be null.");
                }

                _firstName = value;
            }
        }

        /// <summary>
        /// Last name of the account's owner.
        /// </summary>
        /// <exception cref="ArgumentNullException">Value is null.</exception>
        public string LastName
        {
            get
            {
                return _lastName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"{nameof(LastName)} cannot be null.");
                }

                _lastName = value;
            }
        }

        /// <summary>
        /// Current balance on the account.
        /// </summary>
        /// <exception cref="ArgumentException">Value is less than zero.</exception>
        public decimal Balance
        {
            get
            {
                return _balance;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Balance)} is less than zero.");
                }

                _balance = value;
            }
        }

        /// <summary>
        /// Current bonus points on the account.
        /// </summary>
        public long BonusPoints
        {
            get
            {
                return _bonusPoints;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(BonusPoints)} is less than zero.");
                }

                _bonusPoints = value;
            }
        }

        /// <summary>
        /// Account's closed status.
        /// </summary>
        public bool IsClosed { get; private set; }

        protected abstract int ReplenishBalanceCoeff { get; }

        protected abstract int ReplenishValueCoeff { get; }

        protected abstract int WithdrawBalanceCoeff { get; }

        protected abstract int WithdrawValueCoeff { get; }

        #endregion

        #region Public methods

        /// <summary>
        /// Replenish amount to the account.
        /// </summary>
        /// <param name="amount">Amount.</param>
        public void Replenish(decimal amount)
        {
            if (IsClosed)
            {
                throw new InvalidOperationException($"Account is closed. All operations are unavailable.");
            }

            Balance += amount;
            BonusPoints += (long)((ReplenishBalanceCoeff * Balance) + (ReplenishValueCoeff * amount));
        }

        /// <summary>
        /// Withdraw amount from the account.
        /// </summary>
        /// <param name="amount">Amount.</param>
        public void Withdraw(decimal amount)
        {
            if (IsClosed)
            {
                throw new InvalidOperationException($"Account is closed. All operations are unavailable.");
            }

            Balance -= amount;
            BonusPoints -= (long)((WithdrawBalanceCoeff * Balance) + (WithdrawValueCoeff * amount));
        }

        #endregion

        #region Overriden Object methods

        /// <summary>
        /// Gets full account info string.
        /// </summary>
        /// <returns>Account's info</returns>
        public override string ToString()
        {
            return $"IBAN: {Iban}" + $"Owner's first name: {FirstName}" + $"Owner's last name: {LastName}" + $"Balance: {Balance.ToString("C")}" + $"Bonus points: {BonusPoints}" + $"Is closed: {IsClosed}";
        }

        #endregion

        #region Private methods

        private static void VerifyInput(string iban, string firstName, string secondName, decimal balance, long bonusPoints)
        {
            if (string.IsNullOrWhiteSpace($"{nameof(iban)} is null or empty."))
            {
                throw new ArgumentException(nameof(iban));
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException($"{nameof(firstName)} is null or empty.");
            }

            if (string.IsNullOrWhiteSpace(secondName))
            {
                throw new ArgumentException($"{nameof(secondName)} is null or empty.");
            }

            if (balance < 0)
            {
                throw new ArgumentException($"{nameof(balance)} is less than zero.");
            }

            if (bonusPoints < 0)
            {
                throw new ArgumentException($"{nameof(bonusPoints)} is less than zero.");
            }
        }

        #endregion
    }
}
