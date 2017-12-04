using System;
using System.Text;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public class IBANGenerator : IIBANGenerator
    {
        private const string CountryId = "BY";
        private const string ControlNumber = "12";
        private const string BankCode = "BBBB";
        private const string BalanceNumber = "3014";

        public string GenerateAccountNumber()
        {
            var result = new StringBuilder(28);
            var rnd = new Random();
            var accountNumber = rnd.Next(1, int.MaxValue);

            var stringNumber = string.Format("{0}", accountNumber.ToString("D13"));

            return result.Append(CountryId).Append(ControlNumber).Append(BankCode).Append(BalanceNumber).Append(stringNumber).ToString();
        }
    }
}
