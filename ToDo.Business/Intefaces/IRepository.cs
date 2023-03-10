using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDo.Business.Models;

namespace ToDo.Business.Intefaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity: Entity
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid Id);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity,bool>> predicate);
        Task<int> SaveChanges();
    }
}
