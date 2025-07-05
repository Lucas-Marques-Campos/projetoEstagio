# API de Gestão de Pedidos

## 📖 Sobre o Projeto

Este projeto é uma API RESTful desenvolvida em C# com ASP.NET Core, como parte de um desafio técnico para uma vaga de estágio em desenvolvimento backend. O objetivo é demonstrar a capacidade de construir um sistema para gerenciar clientes, produtos e pedidos, aplicando boas práticas de programação e design de APIs.

O sistema permite o cadastro completo de clientes e produtos, além do registro de pedidos que associam um cliente a múltiplos produtos, com validação e atualização de estoque em tempo real.

## ✨ Funcionalidades

A API implementa as seguintes funcionalidades obrigatórias:

* **Gestão de Clientes**:
    * `POST /api/clientes`: Criar um novo cliente.
    * `GET /api/clientes`: Listar todos os clientes cadastrados.
    * `GET /api/clientes/{id}`: Buscar um cliente específico pelo seu ID.
    * `DELETE /api/clientes/{id}`: Deletar um cliente.
* **Gestão de Produtos**:
    * `POST /api/produtos`: Criar um novo produto com validação de preço e estoque.
    * `GET /api/produtos`: Listar todos os produtos.
    * `GET /api/produtos/{id}`: Buscar um produto específico pelo seu ID.
    * `DELETE /api/produtos/{id}`: Deletar um produto.
* **Gestão de Pedidos**:
    * `POST /api/pedidos`: Criar um novo pedido, associando um cliente a múltiplos produtos.
    * `GET /api/pedidos`: Listar todos os pedidos realizados.
* **Regras de Negócio**:
    * Validação de estoque em tempo real ao criar um pedido.
    * Redução automática do estoque do produto após a confirmação do pedido.
    * Cálculo automático do valor total do pedido e dos itens.

## 🛠️ Tecnologias Utilizadas

* [**C#**](https://learn.microsoft.com/pt-br/dotnet/csharp/): Linguagem de programação principal.
* [**.NET**](https://dotnet.microsoft.com/pt-br/): Plataforma de desenvolvimento.
* [**ASP.NET Core**](https://dotnet.microsoft.com/pt-br/apps/aspnet): Framework para construção da API Web.
* [**Swagger (Swashbuckle)**](https://www.swagger.io/): Ferramenta para documentação e teste interativo da API.
* **Armazenamento em Memória**: Os dados são armazenados em listas estáticas em memória para simplificar a execução do projeto, conforme permitido nos requisitos.

## 🚀 Como Executar o Projeto

Para executar este projeto, você precisará ter o SDK do .NET instalado na sua máquina.

1.  **Clone o Repositório**
    ```
    git clone [https://github.com/Lucas-Marques-Campos/projetoEstagio.git](https://github.com/Lucas-Marques-Campos/projetoEstagio.git)
    cd projetoEstagio
    ```
2.  **Restaure as Dependências**
    Abra o terminal na pasta raiz do projeto e execute:
    ```
    dotnet restore
    ```
3.  **Execute a API**
    Ainda no terminal, execute o comando para iniciar o servidor:
    ```
    dotnet run
    ```
4.  **Acesse a API**
    Após a execução, a API estará disponível. A mensagem no terminal indicará as URLs, geralmente:
    * `http://localhost:5000`
5.  **Teste com o Swagger UI**
    Para testar os endpoints de forma visual e interativa, abra seu navegador e acesse a interface do Swagger:
    `http://localhost:5000/swagger`

## Endpoints da API

A seguir, a lista de todos os endpoints disponíveis.

#### Clientes

* **`POST /api/clientes`**
    * Cria um novo cliente.
    * **Corpo da Requisição (JSON):**
        ```
        {
          "nome": "Nome do Cliente",
          "cpf": "123.456.789-00",
          "email": "cliente@email.com"
        }
        ```
* **`GET /api/clientes`**
    * Retorna a lista de todos os clientes.
* **`GET /api/clientes/{id}`**
    * Retorna um cliente específico.
* **`DELETE /api/clientes/{id}`**
    * Deleta um cliente específico.

#### Produtos

* **`POST /api/produtos`**
    * Cria um novo produto.
    * **Corpo da Requisição (JSON):**
        ```
        {
          "nome": "Nome do Produto",
          "preco": 99.90,
          "estoque": 100
        }
        ```
* **`GET /api/produtos`**
    * Retorna a lista de todos os produtos.
* **`GET /api/produtos/{id}`**
    * Retorna um produto específico.
* **`DELETE /api/produtos/{id}`**
    * Deleta um produto específico.

#### Pedidos

* **`POST /api/pedidos`**
    * Cria um novo pedido.
    * **Corpo da Requisição (JSON):**
        ```
        {
          "clienteId": "guid_do_cliente_existente",
          "itens": [
            {
              "produtoId": "guid_do_produto_existente",
              "quantidade": 2
            }
          ]
        }
        ```
* **`GET /api/pedidos`**
    * Retorna a lista de todos os pedidos criados.