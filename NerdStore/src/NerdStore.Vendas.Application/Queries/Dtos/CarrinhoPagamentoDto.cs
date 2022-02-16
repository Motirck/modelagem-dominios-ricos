namespace NerdStore.Vendas.Application.Queries.Dtos;

public class CarrinhoPagamentoDto
{
    public string NomeCartao { get; set; }
    public string NumeroCartao { get; set; }
    public string ExpiracaoCartao { get; set; }
    public string CvvCartao { get; set; }
}