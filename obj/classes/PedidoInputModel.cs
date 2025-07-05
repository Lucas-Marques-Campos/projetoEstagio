using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto.obj.classes
{
   public class ItemInputModel
{
    public Guid ProdutoId { get; set; }
    public int Quantidade { get; set; }
}
    public class PedidoInputModel
    {
        public Guid ClienteId { get; set; }
        public List<ItemInputModel> Itens { get; set; }

        public PedidoInputModel()
        {
            Itens = new List<ItemInputModel>();
        }
    }
}