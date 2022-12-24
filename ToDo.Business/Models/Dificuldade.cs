using System.Data.SqlTypes;

namespace ToDo.Business.Models
{
    public class Dificuldade : Entity
    {
        public string Nome { get; set; }
        public string  Pontos { get; set; }

        public Usuario Usuario { get; set; }

        public Tarefa Tarefa { get; set; }
    }
}