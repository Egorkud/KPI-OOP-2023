using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorna_4.Options.Accounts;
using Laboratorna_4.UI.Base;
using Laboratorna_4.DB.Service;

namespace Laboratorna_4.UI
{
    internal class AddPlayer : IUserInterface
    {
        // Екземпляр класу, надаємо доступ до функціоналу
        private readonly AccountService accService;

        // Конструктор класу
        public AddPlayer(AccountService gameAccountService)
        {
            accService = gameAccountService;
        }

        // Реалізація методу Execute інтерфейсу IUserInterface
        public void Execute()
        {
            // Вибір типу облікового запису гравця (взято із попереднього Program)
            Console.WriteLine("********************");
            Console.WriteLine("Input the name of the first player: ");
            string name = Console.ReadLine();
            Account player = AccountSelection(accService, name);
            accService.Create(player);
        }

        // Метод для вибору типу облікового запису (взято із попереднього Program)
        private Account AccountSelection(AccountService service, string userName)
        {
            Console.WriteLine("Choose your account type (1, 2, 3):\n" +
                                "1.Standart (Points gaining x1)\n" +
                                "2.Half-bid (Points gaining x0.5)\n" +
                                "3.Double-bid (Points gaining x2)");
            int choose = int.Parse(Console.ReadLine());
            var ID = service.ReadAll().Count();
            switch (choose)
            {
                case 1:
                    var StandartAccount = new StandartAccount(userName, service, ID);
                    return StandartAccount;
                case 2:
                    var HalfAccount = new HalfAccount(userName, service, ID);
                    return HalfAccount;
                case 3:
                    var DoubleAccount = new DoubleAccount(userName, service, ID);
                    return DoubleAccount;
                default:
                    // Перевірка на коректність даних
                    Console.WriteLine("Error! Your answer is incorrect! \nType number 1, 2 or 3");
                    return AccountSelection(service, userName);
            }
        }
    }
}
