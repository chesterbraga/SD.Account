using Microsoft.VisualStudio.TestTools.UnitTesting;
using SD.Transfer.Business.Interfaces;
using SD.Transfer.Business.Models;
using SD.Transfer.Business.Services;
using SD.Transfer.Data.Repository;
using SD.Transfer.Business.Notifications;
using SD.Transfer.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace SD.Transfer.Tests
{
    [TestClass]
    public class LancamentoTests
    {
        private IContaService _contaService;
        private ILancamentoService _lancamentoService;
        private AccountDbContext dbctx;

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<AccountDbContext>().Options;
            dbctx = new AccountDbContext(options);

            _contaService = new ContaService(new ContaRepository(dbctx), new Notifier());

            _lancamentoService = new LancamentoService(
                _contaService, 
                new ContaRepository(dbctx),
                new LancamentoRepository(dbctx),
                new Notifier());
        }

        [TestCleanup]
        public void Cleanup()
        {
            dbctx.Database.EnsureDeleted();            
            dbctx?.Dispose();
        }

        [TestCategory("Transferência entre Contas")]
        [TestMethod]
        public void TestTransferencia()
        {
            Conta contaOrigem = _contaService.AddConta(new Conta()).Result;
            Conta contaDestino = _contaService.AddConta(new Conta()).Result;

            Lancamento lancamento = new Lancamento
            {
                ContaOrigemId = contaOrigem.Id,
                ContaDestinoId = contaDestino.Id,
                Valor = 100
            };

            lancamento = _lancamentoService.AddLancamento(lancamento).Result;

            Assert.IsNotNull(lancamento.Id, "Id");           
            Assert.AreEqual(contaOrigem.Id, lancamento.ContaOrigemId, "Conta Origem");
            Assert.AreEqual(contaDestino.Id, lancamento.ContaDestinoId, "Conta Destino");
            Assert.AreEqual(100, lancamento.Valor, "Valor");
            Assert.AreEqual(-100, contaOrigem.Saldo, "Saldo Conta Origem");
            Assert.AreEqual(100, contaDestino.Saldo, "Saldo Conta Destino");
        }
    }
}