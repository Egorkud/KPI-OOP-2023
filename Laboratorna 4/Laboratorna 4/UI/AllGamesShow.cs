using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorna_4.UI.Base;
using Laboratorna_4.DB.Service;

namespace Laboratorna_4.UI
{
    internal class AllGamesShow : IUserInterface
    {
        // Екземпляр класу, надаємо доступ до функціоналу
        private readonly AccountService AccServ;

        // Конструктор класу
        public AllGamesShow(AccountService Service)
        {
            AccServ = Service;
        }

        // Реалізація методу Execute інтерфейсу IUserInterface
        public void Execute()
        {
            // Історія ігор (Головна умова (1 лаб))
            // Частина коду взята з Accounts
            Console.WriteLine("********************");
            Console.WriteLine("Information about all Games:");

            // Перегляд кожного гравця в базі даних
            foreach (Account player in AccServ.ReadAll())
            {
                // Отримання результатів гри для поточного гравця
                List<GameResult> GameResults = AccServ.GameResults(player);

                // Перегляд кожного результату гри для поточного гравця
                foreach (GameResult result in GameResults)
                {
                    // Друк інформації про гру, якщо гравець не є учасником гри (виключає дублікати)
                    if (player.UserName != result.Player)
                    {
                        Console.WriteLine($"{result.Player} VS {result.Opponent}, Player {result.Winner} won, played for {result.Rating} rating, Game index №{result.GameIndex + 1}");
                    }
                }
            }
        }
    }
}
