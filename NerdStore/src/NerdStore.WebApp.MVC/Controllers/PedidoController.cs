using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Vendas.Application.Queries;

namespace NerdStore.WebApp.MVC.Controllers;

public class PedidoController : ControllerBase
{
    private readonly IPedidoQueries _pedidoQueries;

    public PedidoController(IPedidoQueries pedidoQueries,
        INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediatorHandler) : base(notifications, mediatorHandler)
    {
        _pedidoQueries = pedidoQueries;
    }

    [Route("meus-pedidos")]
    public async Task<IActionResult> Index()
    {
        return View(await _pedidoQueries.ObterPedidosCliente(ClienteId));
    }
}
