using System;
using System.Collections.Generic;

namespace ProjetoSigma.Application.Interface
{
    public interface IBaseApplication<TEntityDataTransfer> : IDisposable where TEntityDataTransfer : class
    {
        TEntityDataTransfer Add(TEntityDataTransfer model);
        TEntityDataTransfer Update(TEntityDataTransfer model);
        void Delete(int id);
        TEntityDataTransfer GetById(int id);
        IEnumerable<TEntityDataTransfer> GetAll();
    }
}