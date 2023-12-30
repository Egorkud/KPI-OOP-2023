using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorna_4.DB.Entity
{
    // Представлення сутності гри
    internal class GameEntity
    {
        public int PlayRating { get; set; }
        public Account Player1 { get; set; }
        public Account Player2 { get; set; }
        public string Winner { get; set; }
        public int Idefntifier { get; set; }
    }
}
