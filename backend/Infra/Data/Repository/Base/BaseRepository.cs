using backend.Domain.Entites.Base;
using backend.Domain.Interfaces;
using backend.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Infra.Data.Repository.Base
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly MonitoramentoHorasContext _dbContext;

        public BaseRepository(MonitoramentoHorasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual TEntity Create(TEntity entity)
        {
            TEntity result = _dbContext.Set<TEntity>().Add(entity).Entity;
            _dbContext.SaveChanges();

            return result;
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }


        public virtual TEntity GetById(long id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }
    }
}
