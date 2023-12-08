using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorna_2
{
    // Внутрішній клас Program
    internal class Program
    {
        // Вхідний метод програми Main (виконання основної логіки гри)
        public static void Main()
        {
            string answer;
            Account gameAccount = new Account("Player1");
            int rat = gameAccount.CurrentRating;

            // Вибір типу облікового запису для першого гравця
            Console.WriteLine("********************");
            Console.WriteLine("Input the name of the first player: ");
            string firstPlayer = Console.ReadLine();
            Account player1 = AccountSelection(firstPlayer);

            // Вибір типу облікового запису для другого гравця
            Console.WriteLine("....................");
            Console.WriteLine("Input the name of the second player: ");
            string secondPlayer = Console.ReadLine();
            Account player2 = AccountSelection(secondPlayer);

            Console.WriteLine($"\n\nGreat! Let us begin the Game! Keep in mind that the start rating is {rat}");

            // Цикл самої гри
            do
            {
                // Вибір типу наступної гри
                Console.WriteLine("********************");
                Game game = GameType(player1, player2);

                // Проведення безпосередньо гри між гравцями
                game.PlayGame(player1, player2);

                // Друк інформації про гравців на консоль
                player1.OutPlayers();
                player2.OutPlayers();

                // Запит на повторну гру
                Console.WriteLine("Retry? (Y/N)");
                answer = Console.ReadLine();
            } while (answer.ToUpper() == "Y");

            // Друк остаточного результату гри
            Console.WriteLine("********************");
            player1.OutPlayers();
            player2.OutPlayers();

            // Друк історії гри
            Console.WriteLine("********************");
            player1.GetStats();
        }

        // Метод для вибору типу облікового запису
        private static Account AccountSelection(string userName)
        {
            Console.WriteLine("Choose your account type (1, 2, 3): \n1.Standart (Points gaining x1)\n2.Half-bid (Points gaining x0.5)\n3.Double-bid (Points gaining x2)");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    return new StandartAccount(userName);
                case 2:
                    return new HalfAccount(userName);
                case 3:
                    return new DoubleAccount(userName);
                default:
                    // Перевірка на коректність даних
                    Console.WriteLine("Error! Your answer is incorrect! \nType number 1, 2 or 3");
                    return AccountSelection(userName);
            }
        }

        // Метод для вибору типу гри
        private static Game GameType(Account player1, Account player2)
        {
            // Створення екземпляру класу та вибір типу гри
            Console.WriteLine("Select the game type: \n1.Standart \n2.Safe mode (No rating lose. The winner gets rating) \n3.Lucky try (You can choose the bid, but the rating will not change)");
            int choose = int.Parse(Console.ReadLine());
            GameFactory factory = new GameFactory();
            switch (choose)
            {
                case 1:
                    return factory.GameStandart(player1, player2);
                case 2:
                    return factory.GameSafemode(player1, player2);
                case 3:
                    return factory.GameLuckyTry(player1, player2);
                default:
                    // Перевірка на коректність дани
                    Console.WriteLine("Error! Your answer is incorrect! \nType number 1, 2 or 3");
                    return GameType(player1, player2);
            }
        }
    }
}
