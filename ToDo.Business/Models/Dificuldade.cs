using System.Data.SqlTypes;

namespace ToDo.Business.Models
{
    public class Dificuldade : Entity
    {
        public string Nome { get; set; }
        public string  Pontos { get; set; }

        public IEnumerable<Tarefa> Tarefa { get; set; }
    }
}