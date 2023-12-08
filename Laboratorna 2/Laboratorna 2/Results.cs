using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorna_2
{
    //Представлення результату гри (Головна умова (1 лаб))
    internal class GameResult
    {
        // Друк результату ігор
        public string Player { get; }
        public string Opponent { get; }
        public string Winner { get; }
        public int Rating { get; }
        public int GameIndex { get; }

        // Ініціалізація з переданими параметрами
        public GameResult(string player, string opponent, string winner, int rating, int gameIndex)
        {
            Player = player;
            Opponent = opponent;
            Winner = winner;
            Rating = rating;
            GameIndex = gameIndex;
        }
    }
}
