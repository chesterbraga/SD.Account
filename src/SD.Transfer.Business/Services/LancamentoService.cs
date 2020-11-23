using System.Threading.Tasks;
using SD.Transfer.Business.Interfaces;
using SD.Transfer.Business.Models;
using SD.Transfer.Business.Models.Validations;
using System;

namespace SD.Transfer.Business.Services
{
    public class LancamentoService : BaseService, ILancamentoService
    {
        private readonly IContaService _contaService;
        private readonly IContaRepository _contaRepository;
        private readonly ILancamentoRepository _lancamentoRepository;

        private async Task<bool> Validate(Lancamento lancamento)
        {
            bool valid = false;

            if (IsValid(new LancamentoValidation(), lancamento))
            {
                valid = true;

                Conta contaOrigem = await _contaService.GetConta(lancamento.ContaOrigemId);
                Conta contaDestino = await _contaService.GetConta(lancamento.ContaDestinoId);

                if (contaOrigem == null)
                {
                    Notify("A conta origem não está cadastrada");
                    valid = false;
                }

                if (contaDestino == null)
                {
                    Notify("A conta destino não está cadastrada");
                    valid = false;
                }
            }

            return valid;
        }        

        public LancamentoService(
            IContaService contaService,
            IContaRepository contaRepository,
            ILancamentoRepository lancamentoRepository,
            INotifier notifier) : base(notifier)
        {
            _contaService = contaService;
            _contaRepository = contaRepository;
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<Lancamento> AddLancamento(Lancamento lancamento)
        {
            if (await Validate(lancamento))
            {
                lancamento.Id = Guid.NewGuid().ToString();
                await _lancamentoRepository.Add(lancamento);

                Conta contaOrigem = await _contaService.GetConta(lancamento.ContaOrigemId);
                Conta contaDestino = await _contaService.GetConta(lancamento.ContaDestinoId);

                contaOrigem.Saldo -= lancamento.Valor;
                contaDestino.Saldo += lancamento.Valor;

                await _contaRepository.SaveChanges();
            }

            return lancamento;
        }
        
        public void Dispose()
        {
            _lancamentoRepository?.Dispose();
        }
    }
}