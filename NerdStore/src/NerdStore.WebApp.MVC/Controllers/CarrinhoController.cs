using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Vendas.Application.Commands;

namespace NerdStore.WebApp.MVC.Controllers
{
    public class CarrinhoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IMediatorHandler _mediatorHandler;

        public CarrinhoController(INotificationHandler<DomainNotification> notifications,
                                  IProdutoAppService produtoAppService, 
                                  IMediatorHandler mediatorHandler) : base(notifications, mediatorHandler)
        {
            _produtoAppService = produtoAppService;
            _mediatorHandler = mediatorHandler;
        }

        [Route("meu-carrinho")]
        public async Task<IActionResult> Index()
        {
            return null;
        }

        [HttpPost]
        [Route("meu-carrinho")]
        public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            if (produto == null) return BadRequest();

            if (produto.QuantidadeEstoque < quantidade)
            {
                TempData["Erro"] = "Produto com estoque insuficiente";
                return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
            }

            var command = new AdicionarItemPedidoCommand(ClienteId, produto.Id, produto.Nome, quantidade, produto.Valor);
            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return RedirectToAction("Index");
            }

            TempData["Erros"] = "Produto Indisponível";
            return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
        }

    }
}