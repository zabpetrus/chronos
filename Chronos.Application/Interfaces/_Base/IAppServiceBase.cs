using Chronos.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Application.Interfaces._Base
{
    public interface IAppServiceBase <EntityViewModel> where EntityViewModel : class
    {
        public int DeleteById(long id);
        public List<EntityViewModel> GetAll();
        public EntityViewModel GetById(long id);
        public EntityViewModel Update(EntityViewModel model);
        public EntityViewModel Create(EntityViewModel model);

    }
}
