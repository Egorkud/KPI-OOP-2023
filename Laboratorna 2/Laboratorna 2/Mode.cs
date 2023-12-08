using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorna_2
{
    // Різні типи ігор, які наслідують базову гру, відповідно зо завдання
    // Клас StandartGame успадкований від Game
    class StandartGame : Game
    {
        // Конструктор класу StandartGame
        public StandartGame(Account player1, Account player2) : base(player1, player2) { }
        // Перевизначений віртуальний метод для отримання оцінювання гри гравцем
        public override int GetGameRating(Account player)
        {
            if (player.UserName == player1.UserName)
            { return playRating; }
            if (player.UserName == player2.UserName)
            { return playRating; }
            return 0;
        }
    }

    // Клас SafeGame успадкований від Game
    class SafeGame : Game
    {
        // Конструктор класу SafeGame
        public SafeGame(Account player1, Account player2) : base(player1, player2) { }

        // Перевизначений віртуальний метод для отримання оцінювання гри гравцем
        public override int GetGameRating(Account player)
        {
            if (player.UserName == player1.UserName && player.UserName == winner) { return playRating; }
            else if (player.UserName == player1.UserName && player.UserName != winner) { return 0; }

            if (player.UserName == player2.UserName && player.UserName == winner) { return playRating; }
            else if (player.UserName == player2.UserName && player.UserName != winner) { return 0; }

            return 0;
        }
    }

    // Клас LuckyTry успадкований від Game
    class LuckyTry : Game
    {
        // Конструктор класу UnrankedGame
        public LuckyTry(Account player1, Account player2) : base(player1, player2) { }

        // Перевизначений віртуальний метод для отримання оцінювання гри гравцем
        public override int GetGameRating(Account player)
        {
            if (player.UserName == player1.UserName) { return 0; }
            if (player.UserName == player2.UserName) { return 0; }
            return 0;
        }
    }
}

