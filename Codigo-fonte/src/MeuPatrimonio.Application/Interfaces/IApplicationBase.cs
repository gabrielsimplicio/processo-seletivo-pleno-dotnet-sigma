using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MeuPatrimonio.Application.Interfaces
{
    public interface IApplicationBase<TEntity, TEntityDto>
    {
        TEntityDto Add(TEntityDto entityDTO);
        void Remove(TEntityDto entityDTO);
        TEntityDto Update(TEntityDto entityDTO);
        TEntityDto GetById(int id);
        IList<TEntityDto> GetAll(Expression<Func<TEntityDto, bool>> filter = null);
    }
}
