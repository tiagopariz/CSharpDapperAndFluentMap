# C#: Dapper com FluentMap

## Introdução

Em 2016 o Felipe Cecon escrever o post [C#: Usando Dapper com FluentMap, Linq e Lambda para consultas](https://medium.com/filipececcon/c-usando-dapper-com-fluentmap-linq-e-lambda-para-consultas-6f3131bff244), onde ele ensina como usar o Dapper com FluentMap usando o .NET Framework 4.5.1, possibilitando o uso de Linq e Lambda dentro do projeto.

Hoje, com o .NET Core em evidência, resolvi criar um novo projeto me inspirando no post dele, onde é possível perceber alguma facilidades e restrições quando se usa um Micro-ORM como o Dapper. E o FluentMap vai ajudar a escrever menos código, principalmente queries em SQL ANSI.

## Criando a solução e os projetos

Eu uso uma extensão do VS Code que facilita bastante a criação de arquivos de solução e projetos, é a [vscode-solution-explorer](https://marketplace.visualstudio.com/items?itemName=fernandoescolar.vscode-solution-explorer) do [Fernando Escobar](https://github.com/fernandoescolar).

Eu vou fornecer os comandos, mas se quiser, conheça e use a extensão para agilizar a criação da estrutura pelo VS Code.

### Solução

O nome da solução será CSharpDapperAndFluentMap.sln e ficará armazenada na pasta C:\GitHub, mas sinta-se a vontade para usar o seu próprio diretório.

`dotnet "new" "sln" "-n" "CSharpDapperAndFluentMap" "-o" "c:\GitHub\CSharpDapperAndFluentMap"`

Adicione na raiz do projeto o arquivo **[global.json](global.json)**, para definir a versão do .NET Core:

`{
  "sdk": {
    "version": "2.2.204"
  }
}`

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

Use o arquivo **[CreateDB.sql](/sql/CreateDB.sql)** para criar o banco de dados com as tabelas e os dados de exemplo.

![Diagram](/sql/DapperDiagram.PNG)

## Entidades

Crie no projeto de domínio, na pasta Entities, as classes:

- Entity
- Category
- Person
- Project
- PersonProject
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
- ProjectQuery
- ProjectRepository
- PersonProjectQuery
- PersonProjectRepository
- PriorityQuery
- PriorityRepository
- TicketQuery
- TicketRepository

## Mapeamentos

Crie uma pasta chamada Mappings no projeto de dados, e inclua os mapeamentos:

- CategoryMap
- PersonMap
- ProjectMap
- PersonProjectMap
- PriorityMap
- TicketMap

Crie a classe RegisterMappings na raiz do projeto de dados.

## Projeto Console

Adicione referência ao projeto de dados e domínio no projeto de console.

Adicione uma chamada ao método Register da classe RegisterMappings no método Main da classe Program.