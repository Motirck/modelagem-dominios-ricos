using MediatR;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;

namespace NerdStore.Vendas.Application.Events;

public class PedidoEventHandler : 
    INotificationHandler<PedidoRascunhoIniciadoEvent>,
    INotificationHandler<PedidoAtualizadoEvent>,
    INotificationHandler<PedidoItemAdicionadoEvent>,
    INotificationHandler<PedidoEstoqueRejeitadoEvent>
{
    public Task Handle(PedidoRascunhoIniciadoEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(PedidoAtualizadoEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(PedidoItemAdicionadoEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(PedidoEstoqueRejeitadoEvent notification, CancellationToken cancellationToken)
    {
        // Cancelar o processamento do pedido - retornar erro para o cliente
        return Task.CompletedTask;
    }
}