using MediatR;
using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Commands;

public class PedidoCommandHandler : IRequestHandler<AdicionarItemPedidoCommand, bool>
{
    public async Task<bool> Handle(AdicionarItemPedidoCommand message, CancellationToken cancellationToken)
    {
        if (!ValidarComando(message)) return false;

        return true; // TODO: Continuar implementação do handler
    }
    
    private bool ValidarComando(Command message)
    {
        if (message.EhValido()) return true;

        foreach (var error in message.ValidationResult.Errors)
        {
            // TODO: publIcar notificação
        }

        return false;
    }
}