# Recipe API

API REST para gerenciar receitas e ingredientes com relação muitos-para-muitos, desenvolvida em .NET 8 com PostgreSQL.
Descrição
A Recipe API permite criar, ler, atualizar e excluir receitas e ingredientes. Cada receita pode ter múltiplos ingredientes com quantidades específicas, e cada ingrediente pode ser associado a várias receitas. A API usa PostgreSQL para persistência e inclui logging para depuração.

## Pré-requisitos

.NET 8 SDK: Download
PostgreSQL: Versão 13 ou superior, com pgAdmin ou outro cliente
Git: Para clonar o repositório

## Configuração

Clonar o repositório:
`git clone <url-do-repositorio>`
`cd RecipeApi`

## Restaurar dependências:

`dotnet restore`

## Configurar a string de conexão:

Edite o arquivo appsettings.json:{

```
"ConnectionStrings": {
"DefaultConnection": "Host=localhost;Database=receitas-db;Username=postgres;Password=sua_senha"
},
"UsePostgreSQL": true
}
```

## Aplicar migrações:

```dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Executar a API:

`dotnet run`

Acessar o Swagger:

Abra https://localhost:<porta>/swagger no navegador (a porta é exibida no console).
Use o Swagger para testar os endpoints.

## Endpoints

### Ingredientes

- GET /Ingredientes: Lista todos os ingredientes.
- GET /Ingredientes/{id}: Obtém um ingrediente pelo ID.
- POST /Ingredientes: Cria um novo ingrediente.

Exemplo:

```
{
"nome": "Farinha de Trigo",
"unidadeMedida": "Gramas"
}
```

Valores válidos para unidadeMedida: Gramas, Quilogramas, Litros, Mililitros, ColherSopa, ColherChá, Xicara, Unidade, Pitada.

- PUT /Ingredientes/{id}: Atualiza um ingrediente.
  Exemplo:

```
{
"ingredienteId": 1,
"nome": "Farinha de Trigo Integral",
"unidadeMedida": "Quilogramas"
}
```

- DELETE /Ingredientes/{id}: Exclui um ingrediente (se não estiver associado a receitas).

### Receitas

- GET /Receitas: Lista todas as receitas.
- GET /Receitas/{id}: Obtém uma receita pelo ID.
- POST /Receitas: Cria uma nova receita.
  Exemplo:

```
{
"nome": "Bolo de Chocolate",
"modoPreparo": "Misturar e assar por 30 minutos.",
"ingredientes": [
{ "ingredienteId": 1, "quantidade": 200 },
{ "ingredienteId": 2, "quantidade": 150 }
]
}
```

- PUT /Receitas/{id}: Atualiza uma receita.
  Exemplo:

```
{
"receitaId": 1,
"nome": "Bolo de Chocolate Modificado",
"modoPreparo": "Misturar, adicionar chocolate, e assar por 35 minutos.",
"ingredientes": [
{ "ingredienteId": 1, "quantidade": 250 },
{ "ingredienteId": 2, "quantidade": 100 }
]
}
```

- DELETE /Receitas/{id}: Exclui uma receita.
