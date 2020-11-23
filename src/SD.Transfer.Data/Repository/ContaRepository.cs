using SD.Transfer.Business.Interfaces;
using SD.Transfer.Business.Models;
using SD.Transfer.Data.Context;

namespace SD.Transfer.Data.Repository
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(AccountDbContext context) : base(context) { }        
    }
}