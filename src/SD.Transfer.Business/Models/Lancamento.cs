using System;

namespace SD.Transfer.Business.Models
{
    public class Lancamento : Entity
    {
        public string ContaOrigemId { get; set; }
        public string ContaDestinoId { get; set; }
        public decimal Valor { get; set; }
    }    
}