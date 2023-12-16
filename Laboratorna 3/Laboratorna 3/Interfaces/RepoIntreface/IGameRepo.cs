using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorna_3.DB.Entity;

namespace Laboratorna_3.Interfaces.RepoIntreface
{
    // Інтерфейс репозиторію для базових операцій із сутністю GameEntity
    internal interface IGameRepo
    {
        public void Create(GameEntity gameEntity);
        public List<GameEntity> ReadAll();
        public GameEntity ReadById(int Id);
        public void Update(GameEntity gameEntity);
        public void Delete(GameEntity gameEntity);
    }
}
