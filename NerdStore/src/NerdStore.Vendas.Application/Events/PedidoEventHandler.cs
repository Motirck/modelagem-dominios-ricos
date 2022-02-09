using MediatR;

namespace NerdStore.Vendas.Application.Events;

public class PedidoEventHandler : 
    INotificationHandler<PedidoRascunhoIniciadoEvent>,
    INotificationHandler<PedidoAtualizadoEvent>,
    INotificationHandler<PedidoItemAdicionadoEvent>
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
}