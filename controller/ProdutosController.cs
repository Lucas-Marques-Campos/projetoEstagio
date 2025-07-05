using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private static List<Produto> _produtos = new List<Produto>();
        [HttpGet]
        public IActionResult ListarProdutos()
        {
            if (!_produtos.Any())
            {
                var produtosExemplo = new Produto("Produto Exemplo", 10.99m, 100);
                _produtos.Add(produtosExemplo);
            }
            return Ok(_produtos);
        }
        [HttpPost]
        public IActionResult CriarProduto([FromBody] Produto novoProduto)
        {
            _produtos.Add(novoProduto);
            return Ok(novoProduto);
        }
        [HttpGet("{id}")]
        public IActionResult BuscarProdutoPorId(Guid id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarProduto(Guid id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            _produtos.Remove(produto);
            return NoContent();
        }
    }
}