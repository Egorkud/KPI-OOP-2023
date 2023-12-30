using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorna_4.DB.Service;

namespace Laboratorna_4
{
    abstract class Game
    {
        // Властивості класу Game
        public Account player1 { get; set; }
        public Account player2 { get; set; }
        public int playRating { get; set; }
        public string winner { get; set; }
        // Сервіс гри (3 лаб)
        public GameService Gserv { get; set; }

        // Конструктор класу Game
        public Game(Account pl1, Account pl2, GameService service)
        {
            // Ініціалізація гравців
            this.player1 = pl1;
            this.player2 = pl2;

            // Ініціалізація сервісу
            Gserv = service;
        }

        // Метод проведення гри між двома гравцями
        public void PlayGame(Account pl1, Account pl2)
        {
            // Введення користувачем оцінювання гри
            Console.WriteLine("Input the bid of the rating you are playing for: ");
            playRating = int.Parse(Console.ReadLine());

            // Перевірка на допустимість оцінювання гри
            while (playRating <= 0)
            {
                Console.WriteLine("Rating cannot be less than 0");
                playRating = int.Parse(Console.ReadLine());
            }

            // Створення екземпляру класу Random для випадкового вибору переможця
            Random random = new Random();

            // Визначення ініційних значень переможця та індексу гри
            int gameIndex = pl1.GamesCount;

            // Випадковий вибір, який гравець перемагає
            int coin = random.Next(1, 3);

            // Cтворення логіки гри в залежності від випадкового вибору
            if (coin == 1)
            {
                winner = pl1.UserName;
                Console.WriteLine($"Player {pl1.UserName} won");
                pl1.WinGame(this, pl1.UserName, pl2.UserName, winner, gameIndex);
                Console.WriteLine($"Player {pl2.UserName} lost");
                pl2.LoseGame(this, pl1.UserName, pl2.UserName, winner, gameIndex);
            }
            if (coin == 2)
            {
                winner = pl2.UserName;
                Console.WriteLine($"Player {pl2.UserName} won");
                pl2.WinGame(this, pl1.UserName, pl2.UserName, winner, gameIndex);
                Console.WriteLine($"Player {pl1.UserName} lost");
                pl1.LoseGame(this, pl1.UserName, pl2.UserName, winner, gameIndex);
            }
        }
        // Віртуальний метод для отримання оцінювання гри гравцем
        public virtual int GetGameRating(Account player)
        {
            return playRating;
        }
    }
}
