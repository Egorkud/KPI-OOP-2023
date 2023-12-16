using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Laboratorna_3.DB.Entity;
using Laboratorna_3.DB.Repository;
using Laboratorna_3.Interfaces.ServiceInterface;

namespace Laboratorna_3.DB.Service
{
    // Внутрішній сервіс гри, який реалізує інтерфейс IService
    internal class GameService : IGameService
    {
        GameRepo gameRepository; // Репозиторій гри

        // Конструктор класу, що ініціалізує репозиторій гри
        public GameService(DbContext context)
        {
            gameRepository = new GameRepo(context);
        }

        // Метод створення запису гри в базі даних
        public void Create(Game gameEntity)
        {
            gameRepository.Create(Map(gameEntity));
        }

        // Метод оновлення запису гри в базі даних
        public void Update(Game gameEntity)
        {
            gameRepository.Update(Map(gameEntity));
        }

        // Метод видалення запису гри з бази даних
        public void Delete(Game gameEntity)
        {
            gameRepository.Delete(Map(gameEntity));
        }

        // Метод для відображення об'єкта типу Game на об'єкт типу GameEntity
        private GameEntity Map(Game game)
        {
            return new GameEntity
            {
                Player1 = game.player1,
                Player2 = game.player2,
                PlayRating = game.playRating,
                Winner = game.winner,
            };
        }
    }
}
