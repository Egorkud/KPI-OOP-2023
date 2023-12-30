using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorna_4.DB.Service;
using Laboratorna_4.UI.Base;

namespace Laboratorna_4.UI
{
    internal class GameStartCycle : IUserInterface
    {
        // Екземпляри класу, надаємо доступ до їх функціоналів
        private readonly AccountService AccServ;
        private readonly GameService GServ;

        //Конструктор класу
        public GameStartCycle(AccountService gameAccountService, GameService gameService)
        {
            AccServ = gameAccountService;
            GServ = gameService;
        }

        // Реалізація методу Execute інтерфейсу IUserInterface
        public void Execute()
        {
            // Змінні для зберігання обраних гравців
            string answer;
            Account player1;
            Account player2;

            // Запит користувача на вибір гравців за їхніми ID
            Console.WriteLine("Choose players by ID (usually 0 and 1):");
            int FirstPlayer = int.Parse(Console.ReadLine());
            int SecondPlayer = int.Parse(Console.ReadLine());

            // Отримання гравців за їхніми ID
            player1 = AccServ.ReadById(FirstPlayer);
            player2 = AccServ.ReadById(SecondPlayer);

            // Повторення гри за бажанням користувача (взято з основи Program)
            do
            {
                Console.WriteLine("********************");

                // Визначення типу гри та отримання екземпляру гри
                Game game = GameMode(player1, player2, GServ);

                // Проведення гри між обраними гравцями
                game.PlayGame(player1, player2);

                // Запит користувача на повторення гри
                Console.WriteLine("Retry? (Y/N)");
                answer = Console.ReadLine();

            } while (answer.ToUpper() == "Y");
        }


        // Метод для вибору типу гри (взято з основи Program)
        private Game GameMode(Account player1, Account player2, GameService service)
        {
            // Виведення варіантів вибору гравцю
            Console.WriteLine("Select the game type:" +
                            "\n1.Standart" +
                            "\n2.Safe mode (No rating lose. The winner gets rating)" +
                            "\n3.Lucky try (You can choose the bid, but the rating will not change)");

            // Створення екземпляру класу та вибір типу гри
            int choose = int.Parse(Console.ReadLine());
            GameFactory factory = new GameFactory();
            switch (choose)
            {
                case 1:
                    return factory.GameStandart(player1, player2, service);
                case 2:
                    return factory.GameLuckyTry(player1, player2, service);
                case 3:
                    return factory.GameSafemode(player1, player2, service);
                default:
                    // Перевірка на коректність даних
                    Console.WriteLine("Error! Your answer is incorrect! \nType number 1, 2 or 3");
                    return GameMode(player1, player2, service);
            }
        }
    }
}
