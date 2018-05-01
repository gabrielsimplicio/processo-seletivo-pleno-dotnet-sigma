using System;
using System.Collections.Generic;

namespace MeuPatrimonio.Application.Interfaces
{
    public interface IApplicationBase<TEntity, TEntityDto>
    {
        TEntityDto Add(TEntityDto entity);
        void Remove(TEntityDto entity);
        TEntityDto Update(TEntityDto entity);
        TEntityDto GetById(int id);
        IEnumerable<TEntityDto> GetAll(Func<TEntityDto, bool> filter = null);
    }
}
