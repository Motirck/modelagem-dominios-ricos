namespace NerdStore.Vendas.Application.Queries.Dtos;

public class PedidoDto
{
    public Guid Id { get; set; }
    public int Codigo { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataCadastro { get; set; }
    public int PedidoStatus { get; set; }
}