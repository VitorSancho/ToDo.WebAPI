using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Business.ViewModels;

namespace ToDo.Business.Intefaces
{
    public interface ITarefaRepository: IRepository<Tarefa>
    {
        Task<IEnumerable<Tarefa>> ObterProdutosPorFornecedor(Guid Id);
        Task<IEnumerable<Tarefa>> ObterProdutosFornecedores();
        Task<Tarefa> ObterProdutoFornecedor(Guid Id);
    }
}
