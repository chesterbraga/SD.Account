using System.ComponentModel.DataAnnotations;

namespace SD.Transfer.Api.ViewModels
{
    /// <summary>
    /// Conta
    /// </summary>
    public class ContaViewModel
    {
        /// <summary>
        /// Id Conta
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Saldo Conta
        /// </summary>        
        public decimal Saldo { get; set; }        
    }
}