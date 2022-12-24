using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Business.Models;

namespace ToDo.Business.Intefaces
{
    public interface ILogPontuacaoRepository: IRepository<LogPontuacao>
    {
        public Task<IEnumerable<LogPontuacao>> ObterListaLogPontuacaoPorUsuario(Guid usuarioId);

        public Task<LogPontuacao> ObterLogPontuacaoPorTarefa(Guid tarefaId);
    }
}
