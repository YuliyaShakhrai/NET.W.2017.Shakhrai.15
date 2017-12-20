using System;
using System.Linq;
using System.Text;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;
using BLL.ServiceImplementation;
using DAL.Repositories;


namespace ConsolePL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ibanGen = new IBANGenerator();
            var repository = new AccountDBRepository();
            var service = new AccountService(repository, ibanGen);

            var owner = new Owner(1, "Yuliya", "Shakhrai");
            service.OpenAccount(1, 10, 0, false, AccountType.Basic);
            service.OpenAccount(1, 0, 0, false, AccountType.Gold);

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
