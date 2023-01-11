using ToDo.Business.Models;

namespace ToDo.Business.Intefaces
{
    public interface IDificuldadeService : IDisposable
    {
        Task Adicionar(Dificuldade dificuldade);
        Task Atualizar(Dificuldade dificuldade);
        Task Remover(Guid id);
    }
}