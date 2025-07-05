using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace projeto
{
    
    public class Cliente
    {
        
        public Guid IdCliente { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public DateTime DataCadastro { get; private set; }

      
        public Cliente(string nome, string cpf, string email)
        {
            IdCliente = Guid.NewGuid(); 
            Nome = nome;
            Cpf = cpf;
            Email = email;
            DataCadastro = DateTime.Now;  
        }
    }
}