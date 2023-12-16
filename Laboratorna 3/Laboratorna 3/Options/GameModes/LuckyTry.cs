using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorna_3.DB.Service;

namespace Laboratorna_3.Options.GameModes
{
    // Клас LuckyTry успадкований від Game
    class LuckyTry : Game
    {
        // Конструктор класу UnrankedGame
        public LuckyTry(Account player1, Account player2, GameService service) : base(player1, player2, service) { }

        // Перевизначений віртуальний метод для отримання оцінювання гри гравцем
        public override int GetGameRating(Account player)
        {
            if (player.UserName == player1.UserName) { return 0; }
            if (player.UserName == player2.UserName) { return 0; }
            return 0;
        }
    }
}
