using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace projeto
{
    public class Pedido
    {
        public Guid Id { get; private set; } 
        public Guid ClienteId { get; private set; } 
        public DateTime DataPedido { get; private set; }
        public List<ItemPedido> Itens { get; private set; }

          public Pedido(Cliente cliente, List<ItemPedido> itens)
        {
            if (itens == null || !itens.Any())
            {
                throw new ArgumentException("A lista de itens não pode ser nula ou vazia.", nameof(itens));
            }
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "O cliente não pode ser nulo.");
            }

            Id = Guid.NewGuid();
            ClienteId = cliente.Id;
            DataPedido = DateTime.Now;
            Itens = itens;
        }
    
    }
}