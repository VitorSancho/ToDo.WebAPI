using ToDo.Business.Models;

namespace ToDo.Business.Intefaces
{
    public interface IUsuarioService : IDisposable
    {
        Task Adicionar(Usuario produto);
        Task Atualizar(Usuario produto);
        Task Remover(Guid id);
    }
}