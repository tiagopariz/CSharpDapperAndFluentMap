# C#: Dapper com FluentMap

## Introdução

## Crie a solução e os projetos

### Solução

`dotnet "new" "sln" "-n" "CSharpDapperAndFluentMap" "-o" "c:\GitHub\CSharpDapperAndFluentMap"`

### Projeto de dados

`dotnet "new" "classlib" "-lang" "C#" "-n" "CSharpDapperAndFluentMap.Data" "-o" "src\CSharpDapperAndFluentMap.Data"`

`dotnet "sln" "c:\GitHub\CSharpDapperAndFluentMap\CSharpDapperAndFluentMap.sln" "add" "c:\GitHub\CSharpDapperAndFluentMap\src\CSharpDapperAndFluentMap.Data\CSharpDapperAndFluentMap.Data.csproj"`

### Projeto de domínio

`dotnet "new" "classlib" "-lang" "C#" "-n" "CSharpDapperAndFluentMap.Domain" "-o" "src\CSharpDapperAndFluentMap.Domain"`

`dotnet "sln" "c:\GitHub\CSharpDapperAndFluentMap\CSharpDapperAndFluentMap.sln" "add" "c:\GitHub\CSharpDapperAndFluentMap\src\CSharpDapperAndFluentMap.Domain\CSharpDapperAndFluentMap.Domain.csproj"`

### Projeto de console

`dotnet "new" "console" "-lang" "C#" "-n" "CSharpDapperAndFluentMap.Prompt" "-o" "src/CSharpDapperAndFluentMap.Prompt"`

`dotnet "sln" "c:\GitHub\CSharpDapperAndFluentMap\CSharpDapperAndFluentMap.sln" "add" "c:\GitHub\CSharpDapperAndFluentMap\src\CSharpDapperAndFluentMap.Prompt\CSharpDapperAndFluentMap.Prompt.csproj"`

## Banco de dados

Use o arquivo **CreatDb.sql** para criar o banco de dados com as tabelas e os dados de exemplo.

![Diagram](/sql/DapperDiagram.PNG)

## Entidades

Crie no projeto de domínio, na pasta Entities, as classes:

- Entity
- Category
- Person
- Priority
- Ticket

## Pacotes

Instale os pacotes NuGet no projeto de dados:

- Dapper
- Dapper.FluentMap
- Dommel
- Dapper.FluentMap.Dommel
- Microsoft.Extensions.Configuration.FileExtensions
- Microsoft.Extensions.Configuration.Json

## Connection Strings

No projeto de dados adicione o arquivo appsettings.Development.json, que terá a Connections string.

## Repositório e Consultas

No projeto dados adicione uma referência ao projeto de domínio.

`dotnet "add" "c:\GitHub\CSharpDapperAndFluentMap\src\CSharpDapperAndFluentMap.Data\CSharpDapperAndFluentMap.Data.csproj" "reference" "c:\GitHub\CSharpDapperAndFluentMap\src\CSharpDapperAndFluentMap.Domain\CSharpDapperAndFluentMap.Domain.csproj"`

Na pasta Repositories adicione a classe Repository.
Na pasta Queries adicione a classe Query.

Adicione as classes específicas:

- CategoryQuery
- CategoryRepository
- PersonQuery
- PersonRepository
- PriorityQuery
- PriorityRepository
- TicketQuery
- TicketRepository

## Mapeamentos

Crie uma pasta chamada Mappings no projeto de dados, e inclua os mapeamentos:

- CategoryMap
- PersonMap
- PriorityMap
- TicketMap

Crie a classe RegisterMappings na raiz do projeto de dados.

Adicione referência ao projeto de dados e domínio no projeto de console.

Adicioce uma chamado ao método Register da classe RegisterMappings no método Main da classe Program.