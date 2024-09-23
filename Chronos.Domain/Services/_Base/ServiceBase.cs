using Chronos.Domain.Entities._Base;
using Chronos.Domain.Interfaces.Repository._Base;
using Chronos.Domain.Interfaces.Services._Base;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Services._Base
{
    public class ServiceBase<TEntity> : Notifiable<Notification>, IServiceBase<TEntity> where TEntity : Entity
    {

        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Create(TEntity model)
        {
            return _repository.Create(model);   
        }

        public int DeleteById(long id)
        {
            return (_repository.DeleteById(id));
        }

        public List<TEntity> GetAll()
        {
           return _repository.GetAll();
        }

        public TEntity GetById(long id)
        {
            return _repository.GetById(id);
        }

        public TEntity Update(TEntity model)
        {
           return _repository.Update(model);
        }
    }
}
