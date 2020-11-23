using System.ComponentModel.DataAnnotations;

namespace SD.Transfer.Api.ViewModels
{
    /// <summary>
    /// Lancamento
    /// </summary>
    public class LancamentoViewModel
    {
        /// <summary>
        /// Id Lancamento
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Conta Origem
        /// </summary>
        [Required(ErrorMessage = "A conta origem é obrigatório")]        
        public string ContaOrigemId { get; set; }

        /// <summary>
        /// Conta Destino
        /// </summary>
        [Required(ErrorMessage = "A conta destino é obrigatório")]
        public string ContaDestinoId { get; set; }

        /// <summary>
        /// Conta Destino
        /// </summary>
        [Required(ErrorMessage = "O valor da operação é obrigatório")]        
        [Range(1, double.MaxValue, ErrorMessage = "O valor da operação tem que ser maior ou igual a 1")]
        public decimal Valor { get; set; }        
    }
}