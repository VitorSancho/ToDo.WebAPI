using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Business.ViewModels;

namespace ToDo.Business.Intefaces
{
    public interface IUsuarioRepository: IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> ObterProdutosPorFornecedor(Guid Id);
        Task<IEnumerable<Usuario>> ObterProdutosFornecedores();
        Task<Usuario> ObterProdutoFornecedor(Guid Id);
    }
}
