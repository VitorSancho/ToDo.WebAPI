﻿using ToDo.Business.Intefaces;
using ToDo.Business.Models;

namespace ToDo.Business.Services
{
    public class DificuldadeService : BaseService, IDificuldadeService
    {
        private readonly IDificuldadeRepository _dificuldadeRepository;
        private readonly INotificador _notificador;

        public DificuldadeService(IDificuldadeRepository dificuldadeRepository, 
                                 INotificador notificador) : base(notificador)
        {
            _dificuldadeRepository = dificuldadeRepository;
            _notificador = notificador;
        }

        public async Task Adicionar(Dificuldade dificuldade)
        {
            await _dificuldadeRepository.Adicionar(dificuldade);
        }

        public async Task Atualizar(Dificuldade dificuldade)
        {
            await _dificuldadeRepository.Atualizar(dificuldade);
        }

        public void Dispose()
        {
            _dificuldadeRepository?.Dispose();
        }

        public async Task Remover(Guid id)
        {
            await _dificuldadeRepository.Remover(id);
        }
    }
}