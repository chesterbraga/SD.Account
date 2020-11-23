using System.Threading.Tasks;
using SD.Transfer.Business.Models;

namespace SD.Transfer.Business.Interfaces
{
    public interface ILancamentoService
    {
        Task<Lancamento> AddLancamento(Lancamento lancamento);
    }
}