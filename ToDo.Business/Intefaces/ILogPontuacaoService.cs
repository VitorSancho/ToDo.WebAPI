using ToDo.Business.Models;

namespace ToDo.Business.Intefaces
{
    public interface ILogPontuacaoService : IDisposable
    {
        Task Adicionar(LogPontuacao logPontuacao);
        Task Atualizar(LogPontuacao logPontuacao);
        Task Remover(Guid id);
    }
}