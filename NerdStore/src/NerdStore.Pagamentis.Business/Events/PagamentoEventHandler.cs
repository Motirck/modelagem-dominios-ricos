using MediatR;
using NerdStore.Core.DomainObjects.Dtos;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;

namespace NerdStore.Pagamentos.Business.Events;

public class PagamentoEventHandler : INotificationHandler<PedidoEstoqueConfirmadoEvent>
{
    private readonly IPagamentoService _pagamentoService;

    public PagamentoEventHandler(IPagamentoService pagamentoService)
    {
        _pagamentoService = pagamentoService;
    }

    public async Task Handle(PedidoEstoqueConfirmadoEvent message, CancellationToken cancellationToken)
    {
        var pagamentoPedido = new PagamentoPedidoDto
        {
            PedidoId = message.PedidoId,
            ClienteId = message.ClienteId,
            Total = message.Total,
            NomeCartao = message.NomeCartao,
            NumeroCartao = message.NumeroCartao,
            ExpiracaoCartao = message.ExpiracaoCartao,
            CvvCartao = message.CvvCartao
        };

        await _pagamentoService.RealizarPagamentoPedido(pagamentoPedido);
    }
}
