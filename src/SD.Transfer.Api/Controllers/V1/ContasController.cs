using System.Collections.Generic;
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
    /// Contas
    /// </summary>    
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/contas")]    
    public class ContasController : MainController
    {
        private readonly IContaService _contaService;        
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ContasController(
            IContaService contaService,            
            IMapper mapper,
            INotifier notifier,
            ILogger<ContasController> logger) : base(notifier)
        {            
            _contaService = contaService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Cadastrar Conta
        /// </summary>
        /// <param name="contaViewModel">Conta</param>        
        [HttpPost]
        public async Task<ActionResult<ContaViewModel>> AddConta(ContaViewModel contaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            contaViewModel = _mapper.Map<ContaViewModel>
                (await _contaService.AddConta(_mapper.Map<Conta>(contaViewModel)));
            
            return CustomResponse(contaViewModel);
        }

        /// <summary>
        /// Consultar Conta
        /// </summary>
        /// <param name="contaId">Id da Conta</param>
        [HttpGet("{customerId:int}")]
        public async Task<ActionResult<ContaViewModel>> GetConta(string contaId)
        {
            var conta = _mapper.Map<ContaViewModel>(await _contaService.GetConta(contaId));

            if (conta == null)
            {
                return NotFound();
            }

            return conta;
        }

        /// <summary>
        /// Listar Contas
        /// </summary>        
        [HttpGet]
        public async Task<IEnumerable<ContaViewModel>> GetContas()
        {
            return _mapper.Map<IEnumerable<ContaViewModel>>(await _contaService.GetContas());
        }        
    }
}