using System.Collections.Generic;
using System.Threading.Tasks;
using SD.Transfer.Business.Interfaces;
using SD.Transfer.Business.Models;
using System;

namespace SD.Transfer.Business.Services
{
    public class ContaService : BaseService, IContaService
    {
        private readonly IContaRepository _contaRepository;
        
        public ContaService(
            IContaRepository contaRepository,
            INotifier notifier) : base(notifier)
        {
            _contaRepository = contaRepository;            
        }

        public async Task<Conta> AddConta(Conta conta)
        {
            conta.Id = Guid.NewGuid().ToString();
            await _contaRepository.Add(conta);        
            return conta;
        }

        public async Task<Conta> GetConta(string contaId)
        {
            return await _contaRepository.Get(contaId);
        }
        
        public async Task<IEnumerable<Conta>> GetContas()        
        {
            return await _contaRepository.Get();
        }

        public void Dispose()
        {
            _contaRepository?.Dispose();
        }
    }
}