using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDo.Business.Intefaces;
using ToDo.WebAPI.ViewModels;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : MainController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRepository usuarioRepository,IMapper mapper)
        {
            _usuarioRepository =  usuarioRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("teste")]
        public async Task<ActionResult> ObterTodos()
        {
            var usuarios =  _mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioRepository.ObterTodos());

            return Ok(usuarios);
        }
    }
}
