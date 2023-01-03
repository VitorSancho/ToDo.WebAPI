using ToDo.Business.Intefaces;
using ToDo.Business.Models;

namespace ToDo.Business.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly INotificador _notificador;

        public UsuarioService(IUsuarioRepository usuarioRepository, 
                                 INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
            _notificador = notificador;
        }

        public async Task Adicionar(Usuario usuario)
        {
            await _usuarioRepository.Adicionar(usuario);
        }

        public async Task Atualizar(Usuario usuario)
        {
            await _usuarioRepository.Atualizar(usuario);
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

        public async Task Remover(Guid id)
        {
            await _usuarioRepository.Remover(id);
        }
    }
}