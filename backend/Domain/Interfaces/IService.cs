using backend.Domain.Entites.Base;
using FluentValidation;
using System.Collections.Generic;

namespace backend.Domain.Interfaces
{
    public interface IService<T> where T : EntityBase
    {
        T Post<V>(T obj) where V : AbstractValidator<T>;

        T Put<V>(T obj) where V : AbstractValidator<T>;

        void Delete(long id);

        T Get(long id);

        IList<T> Get();
    }
}
