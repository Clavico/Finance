<h1 align="center">
    Finance
</h1>

## 🚀 Tecnologias

Esse projeto foi desenvolvido com as seguintes tecnologias:
- [.Net 6](https://docs.microsoft.com/pt-br/dotnet/core/introduction)
- [Entity Framework](https://docs.microsoft.com/pt-br/ef/core/)
- [PostgreSQL](https://www.postgresql.org/)
- [xUnit](https://docs.microsoft.com/pt-br/dotnet/core/testing/unit-testing-with-dotnet-test)
- [Moq](https://github.com/Moq/moq4/wiki/Quickstart)
- [FluentAssertions](https://fluentassertions.com/)
- [Swagger](https://swagger.io/)

## 💻 Projeto

O Finance é um projeto criado pela Softek para testar o conhecimento através de código.

## 👨‍🏫 Como usar

### Instalação

- Faça a instalação do CLI do .NET na sua máquina: [CLI .NET](https://docs.microsoft.com/pt-br/dotnet/core/install/)
- Verifique se foi instalado corretamente via terminal: `dotnet --version`
- Faça a instalação do Entity Framawork via terminal: `dotnet tool install --global dotnet-ef`
- Faça a instalação do PostgreSQL: `docker run -p 5432:5432 -v /tmp/database:/var/lib/postgresql/data -e POSTGRES_PASSWORD=1234 -d postgres`

### Execução do Projeto

#### Criando o banco de dados
- Acessar a pasta `Finance/Finance` via terminal
- Rodar as migrations: `dotnet-ef database update` 

#### Rodandos os testes
- Acessar a pasta `Finance/Finance.Tests` via terminal
- Rodar os testes: `dotnet test` 

#### Rodando a API
- Acessar a pasta `Finance/Finance` via terminal
- Rodar a aplicação: `dotnet run` 
- Abrir no navegador o Swagger `{PATH}/swagger/index.html`
