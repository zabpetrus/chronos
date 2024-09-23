using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Interfaces.Services._Base
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        public int DeleteById(long id);
        public List<TEntity> GetAll();
        public TEntity GetById(long id);
        public TEntity Update(TEntity model);
        public TEntity Create(TEntity model);
    }
}
