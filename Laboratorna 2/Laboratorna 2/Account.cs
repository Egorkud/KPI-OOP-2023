using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorna_2
{
    // Внутрішній клас GameAccount (Головна умова (1 лаб))
    internal class Account
    {
        // Властивості класу (Основні умови завдання (1 лаб))
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        public List<GameResult> GameResults { get; set; } = new List<GameResult>();

        // Конструктор класу GameAccount
        public Account(string userName)
        {
            UserName = userName;
            CurrentRating = 150;
            GamesCount = 0;
        }

        // Метод, викликається у разі перемоги (Основна умова (1 лаб))
        public void WinGame(Game game, string player1, string player2, string winner, int gameIndex)
        {
            int rating = RatingCalc(game.GetGameRating(this)); // Розрахунок рейтингу за гру
            CurrentRating += rating;                           // Збільшення рейтингу
            GamesCount++;                                      // Збільшення кількості ігор
            GameResults.Add(new GameResult(player1, player2, winner, rating, gameIndex)); // Додавання результату гри
        }

        // Метод, викликається у разі поразки (Основна умова (1 лаб))
        public void LoseGame(Game game, string player1, string player2, string winner, int gameIndex)
        {
            int rating = RatingCalc(game.GetGameRating(this));
            CurrentRating -= rating;
            if (CurrentRating < 1) // Умова контролю рейтингу (завжди більше нуля)
            {
                CurrentRating = 1;
            }
            GamesCount++;
            GameResults.Add(new GameResult(player1, player2, winner, rating, gameIndex));
        }

        // Історія ігор (Головна умова (1 лаб))
        public void GetStats()
        {
            foreach (GameResult result in GameResults)
            {
                Console.WriteLine($"{result.Player} VS {result.Opponent}, Player {result.Winner} won, played for {result.Rating} rating, Game index №{result.GameIndex + 1}");
            }
        }

        // Друк інформації про гравця
        public void OutPlayers()
        {
            Console.WriteLine($"\nPlayer name: {UserName}\nRating: {CurrentRating} \nRounds payed: {GamesCount}\n");
        }

        // Віртуальний метод для розрахунку рейтингу (може бути перевизначений в похідних класах)
        public virtual int RatingCalc(int rating)
        {
            return rating;
        }
    }
}
