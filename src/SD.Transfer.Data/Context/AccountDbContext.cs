using SD.Transfer.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SD.Transfer.Data.Context
{
    public class AccountDbContext : DbContext
    {
        public static readonly ILoggerFactory AccountLoggerFactory
            = LoggerFactory.Create(builder => builder.AddConsole());

        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options) { }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseLoggerFactory(AccountLoggerFactory)
               .UseInMemoryDatabase("AccountDbContext");
        }
    }
}