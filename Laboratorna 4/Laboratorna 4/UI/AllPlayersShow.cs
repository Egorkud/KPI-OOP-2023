using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorna_4.UI.Base;
using Laboratorna_4.DB.Service;

namespace Laboratorna_4.UI
{
    internal class AllPlayersShow : IUserInterface
    {
        // Екземпляр класу, надаємо доступ до функціоналу
        private readonly AccountService AccServ;
        // Конструктор класу
        public AllPlayersShow(AccountService Service)
        {
            AccServ = Service;
        }

        // Реалізація методу Execute() інтерфейсу IUserInterface
        // Друк інформації про гравця
        // Частина коду взята з Accounts
        public void Execute()
        {
            Console.WriteLine("********************");

            // Отримання списку всіх гравців із бази даних
            List<Account> playersList = AccServ.ReadAll();

            // Виведення інформації про кожного гравця (name, rating, id)
            foreach (Account player in playersList)
            {
                Console.WriteLine($"\n*-*-*-*-*-*-*-*-*-*\n" +
                                    $"Player name: {player.UserName}\n" +
                                    $"Rating: {player.CurrentRating}\n" +
                                    $"Player ID: {player.Id}\n" +
                                    $"*-*-*-*-*-*-*-*-*-*\n");
            }
        }
    }
}
