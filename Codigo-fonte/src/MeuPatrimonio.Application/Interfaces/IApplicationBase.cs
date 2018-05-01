using System;
using System.Collections.Generic;

namespace MeuPatrimonio.Application.Interfaces
{
    public interface IApplicationBase<TEntity, TEntityDto>
    {
        TEntityDto Add(TEntityDto entityDTO);
        void Remove(TEntityDto entityDTO);
        TEntityDto Update(TEntityDto entityDTO);
        TEntityDto GetById(int id);
        IEnumerable<TEntityDto> GetAll(Func<TEntityDto, bool> filter = null);
    }
}
