using DevIO.Business.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Business.Intefaces;
using ToDo.Business.Models;

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

        public async Task Atualizar(Fornecedor fornecedor)
        {
            //if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            //if (_TarefaRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
            //{
            //    Notificar("Já existe um fornecedor com este documento infomado.");
            //    return;
            //}

            await _TarefaRepository.Atualizar(fornecedor);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _TarefaRepository.Atualizar(endereco);
        }

        public async Task Remover(Guid id)
        {
            if (_TarefaRepository.ObterFornecedorProdutosEndereco(id).Result.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
                return;
            }

            var endereco = await _TarefaRepository.ObterEnderecoPorFornecedor(id);

            if (endereco != null)
            {
                await _TarefaRepository.Remover(endereco.Id);
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