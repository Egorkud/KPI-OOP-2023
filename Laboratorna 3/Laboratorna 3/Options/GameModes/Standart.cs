using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorna_3.DB.Service;

namespace Laboratorna_3.Options.GameModes
{
    // Клас StandartGame успадкований від Game
    class StandartGame : Game
    {
        // Конструктор класу StandartGame
        public StandartGame(Account player1, Account player2, GameService service) : base(player1, player2, service) { }
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
}
