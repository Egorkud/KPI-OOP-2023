using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Laboratorna_4.DB.Entity;
using Laboratorna_4.DB.Repository;
using Laboratorna_4.Interfaces.ServiceInterface;

namespace Laboratorna_4.DB.Service
{
    // Внутрішній клас AccountService, який реалізує IAccountService
    internal class AccountService : IAccountService
    {
        // Поля класу
        AccountRepo gameAccountRepository; // Репозиторій для облікових записів гравців

        // Конструктор класу, приймає контекст бази даних
        public AccountService(DbContext context)
        {
            gameAccountRepository = new AccountRepo(context);
        }

        // Реалізація методів інтерфейсу IAccountService
        // Отримання результатів гри для конкретного гравця
        public List<GameResult> GameResults(Account entity)
        {
            return MapGameResultList(gameAccountRepository.GameResults(Map(entity)));
        }

        // Створення облікового запису
        public void Create(Account entity)
        {
            gameAccountRepository.Create(Map(entity));
        }

        // Отримання всіх облікових записів
        public List<Account> ReadAll()
        {
            var list = gameAccountRepository.ReadAll().Select(x => x != null ? Map(x) : null).ToList();
            return list;
        }

        // Отримання облікового запису за ідентифікатором
        public Account ReadById(int id)
        {
            return Map(gameAccountRepository.ReadById(id));
        }

        // Додавання результату гри для конкретного гравця
        public void AddGameResult(GameResult gameResult, Account entity)
        {
            gameAccountRepository.AddGameResult(MapGameResult(gameResult), Map(entity));
        }

        // Оновлення облікового запису
        public void Update(Account entity)
        {
            gameAccountRepository.Update(Map(entity));
        }

        // Видалення облікового запису
        public void Delete(Account entity)
        {
            gameAccountRepository.Delete(Map(entity));
        }

        // Mapper-методи для перетворення між Entity та бізнес-моделями
        // Метод перетворення облікового запису гравця на його Entity-представлення
        private AccountEntity Map(Account gameAccount)
        {
            if (gameAccount == null)
            {
                return null;
            }
            return new AccountEntity
            {
                Identifier = gameAccount.Id,
                UserName = gameAccount.UserName,
                CurrentRating = gameAccount.CurrentRating,
                GamesCount = gameAccount.GamesCount,
                GameResults = MapGameResultList(gameAccount.GameResults)
            };
        }

        // Метод перетворення списку результатів гри на їх Entity-представлення
        private List<ResultEntity> MapGameResultList(List<GameResult> gameResultList)
        {
            if (gameResultList == null)
            {
                return null;
            }

            List<ResultEntity> gameResultEntitieList = new List<ResultEntity>();

            foreach (var gameResult in gameResultList)
            {
                gameResultEntitieList.Add(new ResultEntity
                {
                    Player = gameResult.Player,
                    Opponent = gameResult.Opponent,
                    Winner = gameResult.Winner,
                    Rating = gameResult.Rating,
                    GameID = gameResult.GameIndex
                });
            }
            return gameResultEntitieList;
        }

        // Метод перетворення Entity облікового запису гравця на бізнес-модель
        private Account Map(AccountEntity gameAccount)
        {
            return new Account(gameAccount.UserName, this, gameAccount.Identifier)
            {
                AccService = this,
                UserName = gameAccount.UserName,
                CurrentRating = gameAccount.CurrentRating,
                GamesCount = gameAccount.GamesCount,
                GameResults = MapGameResultList(gameAccount.GameResults)
            };
        }

        // Метод перетворення списку Entity об'єкта результатів гри на їх бізнес-модель
        private List<GameResult> MapGameResultList(List<ResultEntity> gameResultEntitieList)
        {
            List<GameResult> gameResultList = new List<GameResult>();
            if (gameResultEntitieList == null)
            {
                return new List<GameResult>();
            }
            foreach (var gameResultEntity in gameResultEntitieList)
            {
                gameResultList.Add(new GameResult
                {
                    Player = gameResultEntity.Player,
                    Opponent = gameResultEntity.Opponent,
                    Winner = gameResultEntity.Winner,
                    Rating = gameResultEntity.Rating,
                    GameIndex = gameResultEntity.GameID
                });
            }
            return gameResultList;
        }

        // Метод перетворення бізнес-моделі результату гри на його Entity-представлення
        private ResultEntity MapGameResult(GameResult gameResult)
        {
            if (gameResult == null)
            {
                return null;
            }

            return new ResultEntity
            {
                Player = gameResult.Player,
                Opponent = gameResult.Opponent,
                Winner = gameResult.Winner,
                Rating = gameResult.Rating,
                GameID = gameResult.GameIndex
            };
        }
    }
}
