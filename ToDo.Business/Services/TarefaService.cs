using DevIO.Business.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Business.Intefaces;
using ToDo.Business.Models;
using ToDo.Business.Models.Validations;

namespace ToDo.Business.Services
{
    public class TarefaService : BaseService, ITarefaService
    {
        private readonly ITarefaRepository _TarefaRepository;
        //private readonly IEnderecoRepository _enderecoRepository;

        public TarefaService(ITarefaRepository tarefaRepository
                                 //,IEnderecoRepository enderecoRepository,
                                 ,INotificador notificador
                                   ) : base(notificador)
        {
            _TarefaRepository = tarefaRepository;
            //_enderecoRepository = enderecoRepository;
        }

        public async Task Adicionar(Tarefa fornecedor)
        {
            //if (!ExecutarValidacao(new FornecedorValidation(), fornecedor) 
            //    || !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

            //if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento).Result.Any())
           // {
             //   Notificar("Já existe um fornecedor com este documento infomado.");
          //      return;
           // }

            await _TarefaRepository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Tarefa fornecedor)
        {
            //if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            //if (_TarefaRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
            //{
            //    Notificar("Já existe um fornecedor com este documento infomado.");
            //    return;
            //}

            await _TarefaRepository.Atualizar(fornecedor);
        }

        public async Task AtualizarEndereco(Tarefa endereco)
        {
            if (!ExecutarValidacao(new TarefaValidation(), endereco)) return;

            await _TarefaRepository.Atualizar(endereco);
        }

        public async Task Remover(Guid id)
        {
            var tarefa = await _TarefaRepository.ObterPorId(id);

            if (tarefa != null)
            {
                await _TarefaRepository.Remover(tarefa.Id);
            }

            await _TarefaRepository.Remover(id);
        }

        public void Dispose()
        {
            _TarefaRepository?.Dispose();
            //_enderecoRepository?.Dispose();
        }
    }
}