using FluentValidation;

namespace SD.Transfer.Business.Models.Validations
{
    public class LancamentoValidation : AbstractValidator<Lancamento>
    {
        public LancamentoValidation()
        {            
            RuleFor(f => f.ContaOrigemId)
                .NotEmpty().WithMessage("A conta origem é obrigatório");
            RuleFor(f => f.ContaDestinoId)
                .NotEmpty().WithMessage("A conta destino é obrigatório");
            RuleFor(f => f.Valor)
                .GreaterThan(0).WithMessage("O valor a transferir tem que ser maior que zero");
        }
    }
}