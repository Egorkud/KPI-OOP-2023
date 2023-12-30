using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Laboratorna_4.DB;
using Laboratorna_4.DB.Service;
using Laboratorna_4.UI.Base;
using Laboratorna_4.UI;
using Laboratorna_4.Interfaces.ServiceInterface;
using System.Windows.Input;


namespace Laboratorna_4
{
    // Внутрішній клас Program
    internal class Program
    {
        // Вхідний метод програми Main (виконання основної логіки гри)
        public static void Main()
        {
            // Ініціалізація об'єктів для роботи з базою даних (3 лаб)
            var context = new DbContext();
            var GService = new GameService(context);
            var AccService = new AccountService(context);

            // Створення масиву для роботи з базою даних (4 лаб)
            // Реалізовано через масив
            IUserInterface[] UIs =
            [
                new AddPlayer(AccService),
                new AllPlayersShow(AccService),
                new GameStartCycle(AccService, GService),
                new AllGamesShow(AccService),
                new OnePlayerShow(AccService),
                new ProgrammeTermination() // Необхідний для коректної роботи через реалізацію масивом
            ];

            // Початковий текст перед грою (4 лаб)
            Console.WriteLine("Before the Game starts, add two players\n");
            // 2 виклики для створення двох акаунтів гравців на початку (4 лаб)
            UIs[0].Execute();
            UIs[0].Execute();

            // Реалізація роботи системи для управління системою за допомогою команд та відображення їх властивостей (4 лаб)
            int answer = 1;
            while ((answer - 1) != 5)
            {
                // Безпосередньо вибір подальших дій (4 лаб)
                Console.WriteLine("********************");
                Console.WriteLine("Choose option (type any number):\n" +
                                "1) Add a new player\n" +
                                "2) Show all player's ID and info\n" +
                                "3) Start the Game\n" +
                                "4) Show info about all played games\n" +
                                "5) Show info about games any player by ID (option 4 help to get all players's ID)\n" +
                                "6) End the programme");
                answer = int.Parse(Console.ReadLine());

                // Виклик дії, відповідно до введеного числа (4 лаб)
                UIs[answer - 1].Execute();
            }
        }
    }
}
