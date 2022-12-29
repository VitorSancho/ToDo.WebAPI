using ToDo.Business.Models;

namespace ToDo.Business.Intefaces
{
    public interface ITarefaService : IDisposable
    {
        Task Adicionar(Tarefa produto);
        Task Atualizar(Tarefa produto);
        Task Remover(Guid id);
    }
}