using NerdStore.Catalogo.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Services;

namespace NerdStore.WebApp.MVC.Controllers.Admin
{
    public class AdminProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public AdminProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet]
        [Route("admin-produtos")]
        public async Task<IActionResult> Index()
        {
            return View(await _produtoAppService.ObterTodos());
        }

        [Route("novo-produto")]
        public async Task<IActionResult> NovoProduto()
        {
            return View(await PopularCategorias(new ProdutoDto()));
        }

        [Route("novo-produto")]
        [HttpPost]
        public async Task<IActionResult> NovoProduto(ProdutoDto produtoDto)
        {
            ModelState.Remove("Categorias");
            if (!ModelState.IsValid) return View(await PopularCategorias(produtoDto));

            await _produtoAppService.AdicionarProduto(produtoDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("editar-produto")]
        public async Task<IActionResult> AtualizarProduto(Guid id)
        {
            return View(await PopularCategorias(await _produtoAppService.ObterPorId(id)));
        }

        [HttpPost]
        [Route("editar-produto")]
        public async Task<IActionResult> AtualizarProduto(Guid id, ProdutoDto produtoDto)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            produtoDto.QuantidadeEstoque = produto.QuantidadeEstoque;

            ModelState.Remove("QuantidadeEstoque");
            ModelState.Remove("Categorias");
            if (!ModelState.IsValid) return View(await PopularCategorias(produtoDto));

            await _produtoAppService.AtualizarProduto(produtoDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("produtos-atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id)
        {
            return View("Estoque", await _produtoAppService.ObterPorId(id));
        }

        [HttpPost]
        [Route("produtos-atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id, int quantidade)
        {
            if (quantidade > 0)
            {
                await _produtoAppService.ReporEstoque(id, quantidade);
            }
            else
            {
                await _produtoAppService.DebitarEstoque(id, quantidade);
            }

            return View("Index", await _produtoAppService.ObterTodos());
        }

        private async Task<ProdutoDto> PopularCategorias(ProdutoDto produto)
        {
            produto.Categorias = await _produtoAppService.ObterCategorias();
            return produto;
        }
    }
}
