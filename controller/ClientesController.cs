using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace projeto
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private static List<Cliente> _clientes = new List<Cliente>();
        [HttpGet]
        public IActionResult ListarClientes()
        {
            if (!_clientes.Any())
            {
                var clienteExemplo = new Cliente("Cliente Exemplo", "123.456.789-00", "exemplo@email.com");
                _clientes.Add(clienteExemplo);
            }
            return Ok(_clientes);
        }
        [HttpPost]
        public IActionResult CriarCliente([FromBody] Cliente novoCliente)
        {
            _clientes.Add(novoCliente);

            return Ok(novoCliente);
        }
        [HttpGet("{id}")]
        public IActionResult BuscarClientePorId(Guid id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarCliente(Guid id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            _clientes.Remove(cliente);
            return NoContent();
        }
        public static Cliente BuscarClientePorIdEstatico(Guid id) => _clientes.FirstOrDefault(c => c.Id == id);
    }
}