using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorna_3.Interfaces.ServiceInterface
{
    // Інтерфейс IAccountService визначає контракт для сервісу управління обліковими записами
    internal interface IAccountService
    {
        public List<GameResult> GameResults(Account entity);
        public void Create(Account entity);
        public List<Account> ReadAll();
        public Account ReadById(int id);
        public void AddGameResult(GameResult gameResult, Account entity);
        public void Update(Account entity);
        public void Delete(Account entity);
    }
}
