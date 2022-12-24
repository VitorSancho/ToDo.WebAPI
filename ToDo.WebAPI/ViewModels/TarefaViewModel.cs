namespace ToDo.WebAPI.ViewModels
{
    public class TarefaViewModel
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public Guid DificuldadeId { get; set; }
        public TimeOnly Hr_planejado { get; set; }
        public string CEP { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public DificuldadeViewModel Dificuldade { get; set; }
    }
}