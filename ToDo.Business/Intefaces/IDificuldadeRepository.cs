using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Business.ViewModels;

namespace ToDo.Business.Intefaces
{
    public interface IDificuldadeRepository: IRepository<Dificuldade>
    {
        Task<IEnumerable<Dificuldade>> ObterProdutosPorFornecedor(Guid Id);
        Task<IEnumerable<Dificuldade>> ObterProdutosFornecedores();
        Task<Dificuldade> ObterProdutoFornecedor(Guid Id);
    }
}
