using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorna_3.DB.Entity
{
    // Представлення сутності результату
    internal class ResultEntity
    {
        public int GameID { get; set; }
        public string Winner { get; set; }
        public string Player { get; set; }
        public int Rating { get; set; }
        public string Opponent { get; set; }
    }
}
