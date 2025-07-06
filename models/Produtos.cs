using System;

namespace projeto
{
    public class Produto{

        public Guid Id { get; private set; }
        public string Nome { get; private set; } 
        public decimal Preco { get; private set; }
        public int Estoque { get; set; }


        public Produto(string nome, decimal preco, int estoque)
        {
            if (preco <= 0){
                throw new ArgumentException("O preço deve ser maior que zero.", nameof(preco));
            }
            if (estoque < 0){
                throw new ArgumentException("O estoque não pode ser negativo.", nameof(estoque));
            }

            Id = Guid.NewGuid();
            Nome = nome; 
            Preco = preco;
            Estoque = estoque;
        }

        public void ReduzirEstoque(int quantidade){
            if (this.Estoque <= quantidade){
                throw new InvalidOperationException("Estoque insuficiente para realizar a operação.");
            }
            this.Estoque -= quantidade;
        }
    }
}
