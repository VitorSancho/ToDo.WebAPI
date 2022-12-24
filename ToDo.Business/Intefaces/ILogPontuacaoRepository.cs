using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Business.ViewModels;

namespace ToDo.Business.Intefaces
{
    public interface ILogPontucaoRepository: IRepository<LogPontuacao>
    {
        Task<IEnumerable<LogPontuacao>> ObterProdutosPorFornecedor(Guid Id);
        Task<IEnumerable<LogPontuacao>> ObterProdutosFornecedores();
        Task<LogPontuacao> ObterProdutoFornecedor(Guid Id);
    }
}
