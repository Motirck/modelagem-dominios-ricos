using MediatR;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;
using NerdStore.Vendas.Application.Commands;

namespace NerdStore.Vendas.Application.Events;

public class PedidoEventHandler : 
    INotificationHandler<PedidoRascunhoIniciadoEvent>,
    INotificationHandler<PedidoAtualizadoEvent>,
    INotificationHandler<PedidoItemAdicionadoEvent>,
    INotificationHandler<PedidoEstoqueRejeitadoEvent>,
    INotificationHandler<PagamentoRealizadoEvent>,
    INotificationHandler<PagamentoRecusadoEvent>

{
    private readonly IMediatorHandler _mediatorHandler;

    public PedidoEventHandler(IMediatorHandler mediatorHandler)
    {
        _mediatorHandler = mediatorHandler;
    }

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

    public async Task Handle(PedidoEstoqueRejeitadoEvent message, CancellationToken cancellationToken)
    {
        // Cancelar o processamento do pedido - retornar erro para o cliente
        await _mediatorHandler.EnviarComando(new CancelarProcessamentoPedidoCommand(message.PedidoId, message.ClienteId));
    }

    public async Task Handle(PagamentoRealizadoEvent message, CancellationToken cancellationToken)
    {
        await _mediatorHandler.EnviarComando(new FinalizarPedidoCommand(message.PedidoId, message.ClienteId));
    }

    public async Task Handle(PagamentoRecusadoEvent message, CancellationToken cancellationToken)
    {
        await _mediatorHandler.EnviarComando(new CancelarProcessamentoPedidoEstornarEstoqueCommand(message.PedidoId, message.ClienteId));
    }
}