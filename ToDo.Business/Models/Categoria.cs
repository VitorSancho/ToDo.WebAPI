using System.Data.SqlTypes;

namespace ToDo.Business.Models
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
    }
}