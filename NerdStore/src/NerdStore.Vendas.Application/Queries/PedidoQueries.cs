using NerdStore.Vendas.Application.Queries.Dtos;
using NerdStore.Vendas.Domain;

namespace NerdStore.Vendas.Application.Queries;

/// <summary>
/// PedidoQueries é a Query Facade da imagem do curso
/// </summary>
public class PedidoQueries : IPedidoQueries
{
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoQueries(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }
    
    public async Task<CarrinhoDto> ObterCarrinhoCliente(Guid clienteId)
    {
        var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(clienteId);
        if (pedido == null) return null;

        var carrinhoDto = new CarrinhoDto
        {
            ClienteId = pedido.ClienteId,
            ValorTotal = pedido.ValorTotal,
            PedidoId = pedido.Id,
            ValorDesconto = pedido.Desconto,
            SubTotal = pedido.Desconto + pedido.ValorTotal
        };

        if (pedido.VoucherId != null)
        {
            carrinhoDto.VoucherCodigo = pedido.Voucher.Codigo;
        }

        foreach (var item in pedido.PedidoItems)
        {
            carrinhoDto.Items.Add(new CarrinhoItemDto
            {
                ProdutoId = item.ProdutoId,
                ProdutoNome = item.ProdutoNome,
                Quantidade = item.Quantidade,
                ValorUnitario = item.ValorUnitario,
                ValorTotal = item.ValorUnitario * item.Quantidade
            });
        }

        return carrinhoDto;
    }

    public async Task<IEnumerable<PedidoDto>> ObterPedidosCliente(Guid clienteId)
    {
        var pedidos = await _pedidoRepository.ObterListaPorClienteId(clienteId);

        pedidos = pedidos.Where(p => p.PedidoStatus == PedidoStatus.Pago || p.PedidoStatus == PedidoStatus.Cancelado)
            .OrderByDescending(p => p.Codigo);

        if (!pedidos.Any()) return null;

        var pedidosDto = new List<PedidoDto>();

        foreach (var pedido in pedidos)
        {
            pedidosDto.Add(new PedidoDto
            {
                ValorTotal = pedido.ValorTotal,
                PedidoStatus = (int)pedido.PedidoStatus,
                Codigo = pedido.Codigo,
                DataCadastro = pedido.DataCadastro
            });
        }

        return pedidosDto;
    }
}