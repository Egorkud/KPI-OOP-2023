using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Laboratorna_4.DB.Entity;

namespace Laboratorna_4.DB
{
    // Внутрішній клас DbContext для роботи з базою даних
    internal class DbContext
    {
        public List<ResultEntity> GameResults { get; set; } // Колекція результатів ігор
        public List<GameEntity> Games { get; set; } // Колекція сутностей гри
        public List<AccountEntity> Accounts { get; set; } // Колекція сутностей облікових записів

        // Конструктор класу DbContext
        public DbContext()
        {
            // Ініціалізація колекцій сутностей
            GameResults = new List<ResultEntity>();
            Games = new List<GameEntity>();
            Accounts = new List<AccountEntity>();
        }
    }
}
