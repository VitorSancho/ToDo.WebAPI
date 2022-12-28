using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDo.Business.Intefaces;
using ToDo.Business.Models;
using ToDo.Data.Repository;
using ToDo.WebAPI.ViewModels;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TarefaController : MainController
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;

        public TarefaController(ITarefaRepository tarefasRepository, IMapper mapper)
        {
            _tarefaRepository = tarefasRepository;
            _mapper = mapper;
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
                var tarefa = _mapper.Map<UsuarioViewModel>(await _tarefaRepository.ObterPorId(id));

                return Ok(tarefa);
            }
            catch { return NotFound(); }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> InserirTarefa([FromBody] TarefaViewModel tarefa)
        {
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
