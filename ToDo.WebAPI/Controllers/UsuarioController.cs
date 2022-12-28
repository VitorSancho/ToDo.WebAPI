using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDo.Business.Intefaces;
using ToDo.Business.Models;
using ToDo.WebAPI.ViewModels;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : MainController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> ObterTodos()
        {
            try
            {
                var usuarios = _mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioRepository.ObterTodos());


                return Ok(usuarios);
            }
            catch { return NotFound(); }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult> ObterUsuario(Guid id)
        {
            try
            {
                var usuarios = _mapper.Map<UsuarioViewModel>(await _usuarioRepository.ObterPorId(id));

                return Ok(usuarios);
            }
            catch { return NotFound(); }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> InserirUsuario([FromBody] UsuarioViewModel usuario)
        {
            var usuarioMapped = _mapper.Map<Usuario>(usuario);
            await _usuarioRepository.Adicionar(usuarioMapped);

                return Ok();

        }
    }
}
