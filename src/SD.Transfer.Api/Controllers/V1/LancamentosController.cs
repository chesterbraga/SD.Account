using System.Threading.Tasks;
using AutoMapper;
using SD.Transfer.Api.ViewModels;
using SD.Transfer.Business.Interfaces;
using SD.Transfer.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SD.Transfer.Api.Controllers.V1
{
    /// <summary>
    /// Lançamentos
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/lancamentos")]
    public class LancamentosController : MainController
    {
        private readonly ILancamentoService _lancamentoService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public LancamentosController(
            ILancamentoService lancamentoService,
            IMapper mapper,
            INotifier notifier,
            ILogger<LancamentosController> logger) : base(notifier)
        {
            _lancamentoService = lancamentoService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Transferência entre contas
        /// </summary>
        /// <param name="lancamentoViewModel">Lancamento</param>
        [HttpPost]
        public async Task<ActionResult<LancamentoViewModel>> Addlancamento(LancamentoViewModel lancamentoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            lancamentoViewModel =
                _mapper.Map<LancamentoViewModel>(
                    await _lancamentoService.AddLancamento(_mapper.Map<Lancamento>(lancamentoViewModel)));

            return CustomResponse(lancamentoViewModel);
        }        
    }
}