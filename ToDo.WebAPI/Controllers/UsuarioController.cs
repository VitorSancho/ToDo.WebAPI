using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/fornecedores")]
    public class UsuarioController : MainController
    {
        public async Task<ActionResult> ObterTodos()
        {


            return Ok();
        }
    }
}
