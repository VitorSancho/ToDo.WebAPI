using System.ComponentModel.DataAnnotations;

namespace ToDo.Business.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Hr_cadastroTarefas { get; set; }
        public string CEP { get; set; }

        public IEnumerable<Tarefa> Tarefas { get; set; }

    }
}