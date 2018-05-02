using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MeuPatrimonio.Application.Interfaces
{
    public interface IApplicationBase<TEntity, TEntityDto>
    {
        TEntityDto Add(TEntityDto entityDTO);
        void Remove(TEntityDto entityDTO);
        void RemoveById(int id);
        TEntityDto Update(TEntityDto entityDTO);
        TEntityDto GetById(int id);
        IList<TEntityDto> GetAll(TEntityDto filter);
        Expression<Func<TEntity, bool>> CreateQueryExpression(TEntityDto filter);
    }
}
