﻿using GerenciadorDePatrimonios.Application.Interface;
using GerenciadorDePatrimonios.Domain.Entities;
using GerenciadorDePatrimonios.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace GerenciadorDePatrimonios.Application
{

    public class ModeloAppService : AppServiceBase<Modelo>, IModeloAppService
    {
        private readonly IModeloService _modeloService;

        public ModeloAppService(IModeloService modeloService)
            : base(modeloService)
        {
            _modeloService = modeloService;
        }

        public IEnumerable<Modelo> BuscarPorId(int id)
        {
            return _modeloService.BuscarPorId(id);
        }

        public List<Modelo> BuscarPorMarcaId(int id)
        {
            return _modeloService.BuscarPorMarcaId(id);
        }

        public List<Modelo> BuscarPorNome(string nome, int marcaId)
        {
            return _modeloService.BuscarPorNome(nome, marcaId);
        }
    }
}
