namespace ToDo.Business.Models
{
    public class Tarefa : Entity
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public Guid DificuldadeId { get; set; }
        public TimeOnly Hr_planejado { get; set; }
        public string CEP { get; set; }
        public Usuario Usuario { get; set; }
        public Dificuldade Dificuldade { get; set; }
    }
}