using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorna_3.DB.Entity;
using Laboratorna_3.Interfaces.RepoIntreface;

namespace Laboratorna_3.DB.Repository
{
    // Клас, що відповідає за взаємодію з базою даних для сутностей типу GameEntity
    internal class GameRepo : IGameRepo
    {
        private DbContext Dbcont; // Об'єкт DbContext для взаємодії з базою даних

        // Конструктор класу, приймає об'єкт DbContext
        public GameRepo(DbContext context)
        {
            Dbcont = context;
        }

        // Метод для створення нового запису в базі даних
        public void Create(GameEntity gameEntity)
        {
            Dbcont.Games.Add(gameEntity);
        }

        // Метод для отримання всіх записів з бази даних
        public List<GameEntity> ReadAll()
        {
            return Dbcont.Games;
        }

        // Метод для отримання запису з бази даних за його ідентифікатором
        public GameEntity ReadById(int Id)
        {
            return Dbcont.Games[Id];
        }


        // Метод для оновлення існуючого запису в базі даних
        public void Update(GameEntity gameEntity)
        {
            // Видалення старого запису та вставлення нового на його місце
            Dbcont.Games.RemoveAt(gameEntity.Idefntifier);
            Dbcont.Games.Insert(gameEntity.Idefntifier, gameEntity);
        }

        // Метод для видалення запису з бази даних
        public void Delete(GameEntity gameEntity)
        {
            // Видалення запису за його ідентифікатором
            Dbcont.Games.RemoveAt(gameEntity.Idefntifier);

            // Перенумерація ідентифікаторів для збереження послідовності
            int NewId = 1;
            foreach (var game in Dbcont.Games)
            {
                Dbcont.Games[NewId].Idefntifier = NewId;
                NewId++;
            }
        }
    }
}
