using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        // Lista em memória para guardar os pedidos criados
        private static List<Pedido> _pedidos = new List<Pedido>();

        // Aqui vamos adicionar nossos métodos...
    }
}