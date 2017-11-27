using System;
using System.Linq;
using System.Text;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string CountryId = "BY";
            const string ControlNumber = "12";
            const string BankCode = "BBBB";
            const string BalanceNumber = "3014";

            var result = new StringBuilder(28);
            var rnd = new Random();
            var accountNumber = rnd.Next(1, int.MaxValue);

            var stringNumber = string.Format("{0}", accountNumber.ToString("D13"));

            result.Append(CountryId).Append(ControlNumber).Append(BankCode).Append(BalanceNumber).Append(stringNumber).ToString();

            Console.ReadLine();
        }
        ////private static readonly IKernel resolver;

        ////static Program()
        ////{
        ////    resolver = new StandardKernel();
        ////    resolver.ConfigurateResolver();
        ////}

        ////static void Main(string[] args)
        ////{
        ////    IAccountService service = resolver.Get<IAccountService>();
        ////    IAccountNumberCreateService creator = resolver.Get<IAccountNumberCreateService>();

        ////    service.OpenAccount("Account owner 1", AccountType.Base, creator);
        ////    service.OpenAccount("Account owner 2", AccountType.Base, creator);
        ////    service.OpenAccount("Account owner 3", AccountType.Silver, creator);
        ////    service.OpenAccount("Account owner 4", AccountType.Base, creator);

        ////    var creditNumbers = service.GetAllAccounts().Select(acc => acc.AccountNumber).ToArray();

        ////    foreach (var t in creditNumbers)
        ////    {
        ////        service.DepositAccount(t, 100);
        ////    }

        ////    foreach (var item in service.GetAllAccounts())
        ////    {
        ////        Console.WriteLine(item);
        ////    }

        ////    foreach (var t in creditNumbers)
        ////    {
        ////        service.WithdrawAccount(t, 10);
        ////    }

        ////    foreach (var item in service.GetAllAccounts())
        ////    {
        ////        Console.WriteLine(item);
        ////    }
        ////}
    }
}
