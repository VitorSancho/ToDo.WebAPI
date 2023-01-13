using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.Business.Intefaces;
using ToDo.Business.Models;
using ToDo.WebAPI.ViewModels;

namespace ToDo.WebAPI.v1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TarefaController : MainController
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;

        public TarefaController(ITarefaRepository tarefasRepository
                                , IMapper mapper
                                , INotificador notificador
                                , IUser user) : base(notificador, user)
        {
            _tarefaRepository = tarefasRepository;
            _mapper = mapper;
            _notificador = notificador;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> ObterTodos()
        {
            try
            {
                var tarefas = _mapper.Map<IEnumerable<TarefaViewModel>>(await _tarefaRepository.ObterTodos());

                return Ok(tarefas);
            }
            catch { return NotFound(); }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult> ObterTarefa(Guid id)
        {
            try
            {
                var tarefaEncontrada = await _tarefaRepository.ObterPorId(id);
                var tarefa = _mapper.Map<TarefaViewModel>(tarefaEncontrada);

                return Ok(tarefa);
            }
            catch { return NotFound(); }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> InserirTarefa([FromBody] TarefaViewModel tarefa)
        {
            if (!ModelState.IsValid) return BadRequest();

            var tarefaMapped = _mapper.Map<Tarefa>(tarefa);
            await _tarefaRepository.Adicionar(tarefaMapped);

            return Ok();
        }

        [HttpPut("id:guid")]
        public async Task<ActionResult> AtualizarTarefa(Guid id, TarefaViewModel tarefa)
        {
            if (id != tarefa.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var tarefaMapped = _mapper.Map<Tarefa>(tarefa);
            await _tarefaRepository.Adicionar(tarefaMapped);

            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> ApagarTarefa(Guid id)
        {
            try
            {
                await _tarefaRepository.Remover(id);

                return Ok();
            }
            catch { return NotFound(); }
        }
    }
}
