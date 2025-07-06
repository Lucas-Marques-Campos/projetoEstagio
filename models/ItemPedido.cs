using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto
{
    public class ItemPedido
    {
        public Guid Id { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public decimal TotalItem => PrecoUnitario * Quantidade;
        public ItemPedido(Produto produto, int quantidade)
        {
            if (quantidade <= 0)
            {
                throw new ArgumentException("A quantidade deve ser maior que zero.", nameof(quantidade));
            }
            if (produto == null)
            {
                throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");
            }
            if (quantidade >= produto.Estoque)
            {
                throw new ArgumentException("A quantidade solicitada excede o estoque disponível.", nameof(quantidade));
            }
            

            Id = Guid.NewGuid();
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = produto.Preco;
        }
      
    }
}
