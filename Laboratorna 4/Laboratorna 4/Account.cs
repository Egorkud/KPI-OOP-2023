using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Laboratorna_4.DB.Service;

namespace Laboratorna_4
{
    // Внутрішній клас GameAccount (Головна умова (1 лаб))
    internal class Account
    {
        // Властивості класу (Основні умови завдання (1 лаб))
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        public List<GameResult> GameResults { get; set; } = new List<GameResult>();

        public int Id { get; set; }                     // Унікальний ідентифікатор гравця (3 лаб)
        public AccountService AccService { get; set; }  // Сервіс для обробки операцій із акаунтом (3 лаб)

        // Конструктор класу Account
        public Account(string userName, AccountService service, int ID)
        {
            UserName = userName;
            CurrentRating = 150;
            GamesCount = 0;
            Id = ID;
            AccService = service;
        }

        // Метод, викликається у разі перемоги (Основна умова (1 лаб))
        public void WinGame(Game game, string pl1, string pl2, string winner, int GameID)
        {
            int rating = RatingCalc(game.GetGameRating(this)); // Розрахунок рейтингу за гру
            CurrentRating += rating;                           // Збільшення рейтингу
            GamesCount++;                                      // Збільшення кількості ігор
            GameResults.Add(new GameResult(pl1, pl2, winner, rating, GameID)); // Додавання результату гри

            AccService.Update(this); // Оновлення гравця в сервісі гравців (3 лаб)
        }

        // Метод, викликається у разі поразки (Основна умова (1 лаб))
        public void LoseGame(Game game, string pl1, string pl2, string winner, int GameID)
        {
            int rating = RatingCalc(game.GetGameRating(this));
            CurrentRating -= rating;
            if (CurrentRating < 1) // Умова контролю рейтингу (завжди більше нуля)
            {
                CurrentRating = 1;
            }
            GamesCount++;
            GameResults.Add(new GameResult(pl1, pl2, winner, rating, GameID));

            AccService.Update(this); // Оновлення гравця в сервісі гравців (3 лаб)
        }

        // Віртуальний метод для розрахунку рейтингу (може бути перевизначений в похідних класах)
        public virtual int RatingCalc(int rating)
        {
            return rating;
        }
    }
}
