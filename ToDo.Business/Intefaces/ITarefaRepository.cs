using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Business.Models;

namespace ToDo.Business.Intefaces
{
    public interface ITarefaRepository: IRepository<Tarefa>
    {
        public Task<Tarefa> ObterTarefaPorUsuario(Guid usuarioId);
        public Task<IEnumerable<Tarefa>> ObterListaTarefasPorUsuario(Guid usuarioId);
        public Task<IEnumerable<Tarefa>> ObterListaTarefasPorDificuldade(Guid dificuldadeId);
    }
}
