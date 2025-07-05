// Estas são as "caixas de ferramentas". A mais importante é a primeira.
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// Colocamos tudo dentro do mesmo "endereço" para se encontrarem.
namespace projeto
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private static List<Pedido> _pedidos = new List<Pedido>();

        [HttpGet]
        public IActionResult ListarPedidos()
        {
            return Ok(_pedidos);
        }

        [HttpPost]
        public IActionResult CriarPedido([FromBody] PedidoInputModel input)
        {
            // Busca o cliente
            var cliente = ClientesController.BuscarClientePorIdEstatico(input.ClienteId);
            if (cliente == null)
            {
                return NotFound($"Cliente com ID {input.ClienteId} não encontrado.");
            }

            var itensDoPedido = new List<ItemPedido>();

            // Valida cada item do pedido
            foreach (var itemInput in input.Itens)
            {
                var produto = ProdutosController.BuscarProdutoPorIdEstatico(itemInput.ProdutoId);
                if (produto == null)
                {
                    return NotFound($"Produto com ID {itemInput.ProdutoId} não encontrado.");
                }

                try
                {
                    // O construtor do ItemPedido já valida o estoque
                    var novoItem = new ItemPedido(produto, itemInput.Quantidade);
                    itensDoPedido.Add(novoItem);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            // Cria o objeto Pedido
            var novoPedido = new Pedido(cliente, itensDoPedido);

            // Atualiza o estoque dos produtos
            foreach (var item in novoPedido.Itens)
            {
                // Acessamos o produto que já está dentro do objeto ItemPedido
                // e chamamos o método para reduzir o estoque
                item.Produto.ReduzirEstoque(item.Quantidade);
            }

            // "Salva" o pedido na nossa lista
            _pedidos.Add(novoPedido);

            // Retorna a resposta de sucesso
            return CreatedAtAction(nameof(ListarPedidos), new { id = novoPedido.Id }, novoPedido);
        }
    }
}