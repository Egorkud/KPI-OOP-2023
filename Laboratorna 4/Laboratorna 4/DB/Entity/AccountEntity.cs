using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorna_4.DB.Entity
{
    // Представлення сутності гравця
    internal class AccountEntity
    {
        public List<ResultEntity> GameResults { get; set; }
        public int GamesCount { get; set; }
        public string UserName { get; set; }
        public int Identifier { get; set; }
        public int CurrentRating { get; set; }
    }
}
