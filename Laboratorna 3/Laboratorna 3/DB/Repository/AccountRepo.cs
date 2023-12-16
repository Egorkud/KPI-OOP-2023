using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorna_3.DB.Entity;
using Laboratorna_3.Interfaces.RepoIntreface;

namespace Laboratorna_3.DB.Repository
{
    // Клас репозиторію для обробки даних облікових записів гравців
    internal class AccountRepo : IAccountRepo
    {
        DbContext Dbcont; // Об'єкт контексту бази даних

        // Конструктор класу, приймає об'єкт контексту бази даних
        public AccountRepo(DbContext context)
        {
            Dbcont = context;
        }

        // Метод створення нового запису про гравця
        public void Create(AccountEntity entity)
        {
            Dbcont.Accounts.Add(entity);
        }

        // Метод отримання усіх записів про гравців
        public List<AccountEntity> ReadAll()
        {
            return Dbcont.Accounts;
        }

        // Метод отримання запису про гравця за його ідентифікатором
        public AccountEntity ReadById(int id)
        {
            return Dbcont.Accounts[id];
        }

        // Метод оновлення інформації про гравця
        public void Update(AccountEntity entity)
        {
            Dbcont.Accounts.RemoveAt(entity.Identifier);
            Dbcont.Accounts.Insert(entity.Identifier, entity);
        }

        // Метод видалення запису про гравця
        public void Delete(AccountEntity entity)
        {
            // Видалення запису за його ідентифікатором
            Dbcont.Accounts.RemoveAt(entity.Identifier);

            // Перенумерація ідентифікаторів після видалення
            int NewId = 1;
            foreach (var gameAccount in Dbcont.Accounts)
            {
                Dbcont.Accounts[NewId].Identifier = NewId;
                NewId++;
            }
        }

        // Метод отримання результатів ігор для конкретного гравця
        public List<ResultEntity> GameResults(AccountEntity entity)
        {
            return entity.GameResults;
        }

        // Метод додавання результату гри для конкретного гравця
        public void AddGameResult(ResultEntity gameResult, AccountEntity entity)
        {
            Dbcont.Accounts[entity.Identifier].GameResults.Add(gameResult);
        }
    }
}
