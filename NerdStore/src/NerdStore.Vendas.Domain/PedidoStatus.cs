namespace NerdStore.Vendas.Domain
{
    public enum PedidoStatus
    {
        Rascunho = 0, // Pedidos no carrinho e que não foram finalizados
        Iniciado = 1, // Ja colocou o endereço, cartão de crédito e etc
        Pago = 4,
        Entregue = 5,
        Cancelado = 6
    }
}