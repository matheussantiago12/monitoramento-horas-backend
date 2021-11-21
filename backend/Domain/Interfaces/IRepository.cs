using backend.Domain.Entites.Base;
using System.Collections.Generic;

namespace backend.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {

        TEntity Create(TEntity item);
        void Delete(TEntity item);
        void Update(TEntity item);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(long id);
    }
}
