using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorna_4.UI.Base;
using Laboratorna_4.DB.Service;

namespace Laboratorna_4.UI
{
    internal class OnePlayerShow : IUserInterface
    {
        // Екземпляр класу, надаємо доступ до функціоналу
        private readonly AccountService AccServ;

        // Конструктор класу
        public OnePlayerShow(AccountService Service)
        {
            AccServ = Service;
        }

        // Реалізація методу Execute інтерфейсу IUserInterface
        public void Execute()
        {
            // Запит ID гравця від користувача
            Console.WriteLine("********************");
            Console.WriteLine("Type the player ID (usually 0 or 1):");
            int playerID = int.Parse(Console.ReadLine());

            // Отримання гравця з бази даних за його ID
            Account player = AccServ.ReadById(playerID);

            // Виведення інформації про ігри гравця
            Console.WriteLine($"Game info of the player {player.UserName}:");
            List<GameResult> GameResults = AccServ.GameResults(player);

            // Виведення деталей кожної гри
            foreach (GameResult result in GameResults)
            {
                Console.WriteLine($"\n{result.Player} VS {result.Opponent}\n" +
                    $"Player {result.Winner} won\n" +
                    $"Played for {result.Rating} rating\n" +
                    $"Game index №{result.GameIndex + 1}\n");
            }
        }
    }
}
