# Projeto StefaniniTestAsp

## Visão Geral

Este projeto é uma aplicação web para gerenciamento de atletas de futebol, construída usando ASP.NET Core 8 e Entity Framework Core. Utiliza um banco de dados PostgreSQL. O Docker é utilizado para utilização do banco de dados, facilitando os testes.

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/products/docker-desktop)

## Começando

### Configurando o Banco de Dados

1. **Inicie o PostgreSQL usando Docker**: Execute o seguinte comando para iniciar um contêiner PostgreSQL.

    ```bash
    docker run --name postgres-db -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=db_teste -p 5432:5432 -d postgres
    ```

2. **Atualize o Banco de Dados**: Execute o seguinte comando para aplicar as migrações e atualizar o banco de dados.

    ```bash
    dotnet ef database update
    ```

### Executando a Aplicação

1. **Abra o Projeto**: Abra o projeto no Visual Studio ou VS Code.

2. **Execute a Aplicação**: Inicie a aplicação usando o IIS Express.

## Estrutura do Projeto

- **Pages**: Contém as Razor Pages para o front-end da aplicação.
- **Models**: Contém os modelos de dados que representam a estrutura dos dados da aplicação.
- **Data**: Contém o contexto do banco de dados e as configurações de migração.
- **wwwroot**: Contém arquivos estáticos como CSS, JavaScript e imagens.

## Funcionalidades

- **Gerenciamento de Atletas**: Criar, ler, atualizar e excluir registros de atletas.
- **Filtragem**: Filtrar atletas por número da camisa, apelido e classificação do IMC.

## Uso

### Criando um Novo Atleta

1. Vá para a página "Inserir Novo Atleta".
2. Preencha os detalhes do atleta e clique em "Salvar".

### Editando um Atleta

1. Vá para a página inicial.
2. Clique em "Editar" ao lado do atleta que você deseja editar.
3. Atualize os detalhes do atleta e clique em "Salvar".

### Excluindo um Atleta

1. Vá para a página inicial.
2. Clique em "Excluir" ao lado do atleta que você deseja excluir.

### Filtrando Atletas

1. Insira os critérios de filtro desejados na página inicial.
2. Clique em "Buscar" para aplicar os filtros.

## Notas

- A aplicação está configurada para ser executada no ambiente de desenvolvimento.
- Certifique-se de que o contêiner PostgreSQL esteja em execução antes de iniciar a aplicação.

## Contato

Para qualquer dúvida ou suporte, entre em contato com [marioc_almeida@outlook.com].
