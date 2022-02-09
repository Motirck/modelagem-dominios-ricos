using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Events;

public class PedidoItemAdicionadoEvent : Event
{
    public Guid ClienteId { get; private set; }
    public Guid PedidoId { get; private set; }
    public Guid ProdutoId { get; private set; }
    public string ProdutoNome { get; private set; }
    public decimal ValorUnitario { get; private set; }
    public int Quantidade { get; private set; }

    public PedidoItemAdicionadoEvent(Guid clienteId, Guid pedidoId, Guid produtoId, string produtoNome, decimal valorUnitario, int quantidade)
    {
        AggregateId = pedidoId;
        ClienteId = clienteId;
        PedidoId = pedidoId;
        ProdutoId = produtoId;
        ProdutoNome = produtoNome;
        ValorUnitario = valorUnitario;
        Quantidade = quantidade;
    }
}