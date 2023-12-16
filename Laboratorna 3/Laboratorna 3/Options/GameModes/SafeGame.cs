using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorna_3.DB.Service;

namespace Laboratorna_3.Options.GameModes
{
    // Клас SafeGame успадкований від Game
    class SafeGame : Game
    {
        // Конструктор класу SafeGame
        public SafeGame(Account player1, Account player2, GameService service) : base(player1, player2, service) { }

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
}
