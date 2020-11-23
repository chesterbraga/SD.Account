using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SD.Transfer.Business.Models;

namespace SD.Transfer.Business.Interfaces
{
    public interface IContaService : IDisposable
    {
        Task<Conta> AddConta(Conta conta);
        Task<Conta> GetConta(string contaId);
        Task<IEnumerable<Conta>> GetContas();
    }
}