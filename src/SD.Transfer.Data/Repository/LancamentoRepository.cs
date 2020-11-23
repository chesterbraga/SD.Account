using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SD.Transfer.Business.Interfaces;
using SD.Transfer.Business.Models;
using SD.Transfer.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace SD.Transfer.Data.Repository
{
    public class LancamentoRepository : Repository<Lancamento>, ILancamentoRepository
    {
        public LancamentoRepository(AccountDbContext context) : base(context) { }        
    }
}