using NerdStore.Vendas.Application.Queries.Dtos;

namespace NerdStore.Vendas.Application.Queries;

public interface IPedidoQueries
{
    Task<CarrinhoDto> ObterCarrinhoCliente(Guid clienteId);
    Task<IEnumerable<PedidoDto>> ObterPedidosCliente(Guid clienteId);
}