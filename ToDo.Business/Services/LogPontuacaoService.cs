
using ToDo.Business.Intefaces;
using ToDo.Business.Models;
using ToDo.Business.Services;

namespace DevIO.Business.Services
{
    public class LogPontuacaoService : BaseService, ILogPontuacaoService
    {
        private readonly ILogPontuacaoRepository _logPontuacaoRepository;

        public LogPontuacaoService(ILogPontuacaoRepository logPontuacaoRepository, 
                                 INotificador notificador) : base(notificador)
        {
            _logPontuacaoRepository = logPontuacaoRepository;
        }

        public async Task Adicionar(LogPontuacao logPontuacao)
        {
            await _logPontuacaoRepository.Adicionar(logPontuacao);
        }

        public async Task Atualizar(LogPontuacao logPontuacao)
        {
            await _logPontuacaoRepository.Atualizar(logPontuacao);
        }

        public void Dispose()
        {
            _logPontuacaoRepository?.Dispose();
        }

        public async Task Remover(Guid id)
        {
            await _logPontuacaoRepository.Remover(id);
        }
    }
}