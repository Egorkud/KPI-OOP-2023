using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Laboratorna_3.DB.Entity;

namespace Laboratorna_3.Interfaces.RepoIntreface
{
    // Інтерфейс, який визначає контракт для роботи з об'єктами типу AccountEntity
    internal interface IAccountRepo
    {
        public void Create(AccountEntity entity);
        public List<AccountEntity> ReadAll();
        public AccountEntity ReadById(int id);
        public void Update(AccountEntity entity);
        public void Delete(AccountEntity entity);
        public List<ResultEntity> GameResults(AccountEntity entity);
        public void AddGameResult(ResultEntity gameResult, AccountEntity entity);
    }
}
