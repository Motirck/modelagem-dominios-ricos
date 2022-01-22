using FluentValidation;
using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Commands
{
    public class AdicionarItemPedidoCommand : Command
    {
        public Guid ClienteId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public AdicionarItemPedidoCommand(Guid clienteId, Guid produtoId, string nome, int quantidade, decimal valorUnitario)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
            Nome = nome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AdicionarItemPedidoValidation : AbstractValidator<AdicionarItemPedidoCommand>
    {
        public AdicionarItemPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("The field {PropertyName} is required");

            RuleFor(c => c.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage("The field {PropertyName} is required");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("The field {PropertyName} is required");

            RuleFor(c => c.Quantidade)
                .GreaterThan(0)
                .WithMessage("The minimum quantity of an item is {ComparisonValue}");

            RuleFor(c => c.Quantidade)
                .LessThan(15)
                .WithMessage("The maximum quantity of an item is {ComparisonValue}");

            RuleFor(c => c.ValorUnitario)
                .GreaterThan(0)
                .WithMessage("The item's value must be greater than {ComparisonValue}");
        }
    }
}
