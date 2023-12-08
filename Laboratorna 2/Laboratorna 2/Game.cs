using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorna_2
{
    abstract class Game
    {
        // Властивості класу Game
        public Account player1 { get; set; }
        public Account player2 { get; set; }
        public int playRating { get; set; }
        public string winner { get; set; }

        // Конструктор класу Game
        public Game(Account player1, Account player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        // Метод проведення гри між двома гравцями
        public void PlayGame(Account player1, Account player2)
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
            int gameIndex = player1.GamesCount;

            // Випадковий вибір, який гравець перемагає
            int coin = random.Next(1, 3);

            // Cтворення логіки гри в залежності від випадкового вибору
            if (coin == 1)
            {
                winner = player1.UserName;
                Console.WriteLine($"Player {player1.UserName} won");
                player1.WinGame(this, player1.UserName, player2.UserName, winner, gameIndex);
                Console.WriteLine($"Player {player2.UserName} lost");
                player2.LoseGame(this, player1.UserName, player2.UserName, winner, gameIndex);
            }
            if (coin == 2)
            {
                winner = player2.UserName;
                Console.WriteLine($"Player {player2.UserName} won");
                player2.WinGame(this, player1.UserName, player2.UserName, winner, gameIndex);
                Console.WriteLine($"Player {player1.UserName} lost");
                player1.LoseGame(this, player1.UserName, player2.UserName, winner, gameIndex);
            }
        }
        // Віртуальний метод для отримання оцінювання гри гравцем
        public virtual int GetGameRating(Account player) { 
            return playRating; 
        }
    }
}
