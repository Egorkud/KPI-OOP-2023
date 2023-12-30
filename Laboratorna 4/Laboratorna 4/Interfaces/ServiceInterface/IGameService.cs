using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorna_4.Interfaces.ServiceInterface
{
    // Інтерфейс сервісу гри
    internal interface IGameService
    {
        public void Create(Game gameEntity);
        public void Update(Game gameEntity);
        public void Delete(Game gameEntity);
    }
}
