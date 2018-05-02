using System;
using System.Collections.Generic;
using AutoMapper;
using ProjetoSigma.Application.Interface;
using ProjetoSigma.Domain.Services.Interface;
using ProjetoSigma.Infra.Data.Interface;

namespace ProjetoSigma.Application
{
    public class BaseApplication<TEntity, TEntityDataTransfer> : IBaseApplication<TEntityDataTransfer>
        where TEntity : class
        where TEntityDataTransfer : class
    {
        private readonly IBaseService<TEntity> _service;
        private readonly IUnitOfWork _unitOfWork;

        protected BaseApplication(IBaseService<TEntity> service, IUnitOfWork unitOfWork)
        {
            _service = service;
            _unitOfWork = unitOfWork;
        }

        public TEntityDataTransfer Add(TEntityDataTransfer model)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                var domain = _service.Add(Mapper.Map<TEntity>(model));

                _unitOfWork.Commit();

                if (domain != null)
                {
                    return Mapper.Map<TEntityDataTransfer>(domain);
                }

                return model;
            }
            catch (Exception e)
            {
                _unitOfWork.RollBakc();
                throw e;
            }
        }

        public TEntityDataTransfer Update(TEntityDataTransfer model)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                var domain = _service.Update(Mapper.Map<TEntity>(model));

                _unitOfWork.Commit();

                if (domain != null)
                {
                    return Mapper.Map<TEntityDataTransfer>(domain);
                }

                return model;
            }
            catch (Exception e)
            {
                _unitOfWork.RollBakc();
                throw e;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                _service.Delete(id);

                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                _unitOfWork.RollBakc();
                throw e;
            }
        }

        public TEntityDataTransfer GetById(int id)
        {
            return Mapper.Map<TEntityDataTransfer>(_service.GetById(id));
        }

        public IEnumerable<TEntityDataTransfer> GetAll()
        {
            var getAll = _service.GetAll();
            return Mapper.Map<IEnumerable<TEntityDataTransfer>>(getAll);
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}