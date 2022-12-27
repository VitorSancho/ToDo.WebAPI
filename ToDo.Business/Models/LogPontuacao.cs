namespace ToDo.Business.Models
{
    public class LogPontuacao : Entity
    {
        public Guid TarefaId { get; set; }
        public TimeOnly Hr_execucao { get; set; }  

        public Tarefa Tarefa { get; set; }
    }

}