using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorna_3
{
    //Представлення результату гри (Головна умова (1 лаб))
    internal class GameResult
    {
        // Друк результату ігор
        public string Player { get; set; }
        public string Opponent { get; set; }
        public string Winner { get; set; }
        public int Rating { get; set; }
        public int GameIndex { get; set; }

        // Ініціалізація з переданими параметрами (конструктор)
        public GameResult(string player, string opponent, string winner, int rating, int gameIndex)
        {
            Player = player;
            Opponent = opponent;
            Winner = winner;
            Rating = rating;
            GameIndex = gameIndex;
        }

        // Конструктор за замовчуванням, який може використовуватися для створення пустого об'єкта GameResult
        // Потрібен для уникнення відсутності аргументу в AccountService (без нього виникне помилка CS7036)
        public GameResult() { }
    }
}
