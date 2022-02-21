using FluentValidation;
using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Commands
{
    public class AtualizarItemPedidoCommand : Command
    {
        public Guid ClienteId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public int Quantidade { get; private set; }

        public AtualizarItemPedidoCommand(Guid clienteId, Guid produtoId, int quantidade)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AtualizarItemPedidoValidation : AbstractValidator<AtualizarItemPedidoCommand>
    {
        public AtualizarItemPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("The field {PropertyName} is required");

            RuleFor(c => c.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage("The field {PropertyName} is required");

            RuleFor(c => c.Quantidade)
                .GreaterThan(0)
                .WithMessage("The value {PropertyName} must be greater than {ComparisonValue}");

            RuleFor(c => c.Quantidade)
                .LessThan(15)
                .WithMessage("The value {PropertyName} must be less than {ComparisonValue}");
        }
    }
}
