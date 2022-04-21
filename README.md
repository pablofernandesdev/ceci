<h1 align="center"> Ceci </h1>

> Status do Projeto: Em desenvolvimento :construction:

## Descrição do Projeto
<p align="justify"> O projeto Ceci é um projeto que possui arquitetura e funcionalidade básicas para o início de novos projetos. </p>

## Navegar entre os tópicos
<!--ts-->
   * [Principais funcionalidades](#principais-funcionalidades)
   * [O que as funcionalidades do projeto é capaz de fazer](#o-que-as-funcionalidades-do-projeto-é-capaz-de-fazer-computer)
   * [Linguagens, libs e tecnologias utilizadas](#linguagens-libs-e-tecnologias-utilizadas-books)
   * [Como rodar a aplicação](#como-rodar-a-aplicação-arrow_forward)
      * [Clonando o projeto e instalando dependências](#clonando-o-projeto-e-instalando-dependências)
      * [Criando banco de dados com o Code First](#criando-banco-de-dados-com-o-code-first)
      * [Rodando a aplicação](#rodando-a-aplicação)
      * [Executando os testes](#executando-os-testes)
   * [Referências](#referências-newspaper)
<!--te-->

## Principais funcionalidades
- Autenticação
    - Autenticação de usuários por login e senha
- Usuário
    - Armazemamento persistente de usuários (criar, ler, atualizar e excluir)
- Perfil
    - Armazemamento persistente de perfil (criar, ler, atualizar e excluir)
- Relatórios
    - Importação e geração de relatórios em Excel

## O que as funcionalidades do projeto é capaz de fazer :computer:

:white_check_mark: Manter autenticação do usuário com base nos dados cadastrados, perfil e geração de token JWT 

:white_check_mark: Atualizar token de autenticação do usuário

:white_check_mark: Recuperar senha do usuário

:white_check_mark: Redefinir senha do usuário

:white_check_mark: Validar cadastro de novos usuários com a confirmação de um código enviado por email

:white_check_mark: Manter cadastro de usuários 

:white_check_mark: Manter perfis de usuários 

:white_check_mark: Vincular perfis a usuários 

:white_check_mark: Execução de serviço em background (envio de emails e importação de relatórios)

:white_check_mark: Importação de dados de arquivo Execel para a base de dados

:white_check_mark: Geração de relatórios em excel com base em filtros enviados na requisição

## Linguagens, libs e tecnologias utilizadas :books:

- [.NET Core](https://dotnet.microsoft.com/en-us/download/dotnet/5.0): versão 5.0
    - Plataforma de desenvolvimento gratuita e de software livre para a criação de muitos tipos de aplicativos.
- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/): versão 8.0
    - Linguagem de programação moderna, orientada a objeto e fortemente digitada.
- [Hangfire](https://www.hangfire.io/): versão 1.7
    - Biblioteca que permite realizar o processamento em segundo plano em aplicativos .NET e .NET Core.
- [Bogus](https://github.com/bchavez/Bogus): versão 33.1
    - Gerador de dados falsos simples e lógico para linguagens .NET como C # , F # e VB.NET . 
- [Moq](https://github.com/moq): versão 4.16
    - Biblioteca de simulação para .NET 
- [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore): versão 6.1.4
    - Conjunto de ferramentas Swagger para APIs criadas com ASP.NET Core. Gere uma bela documentação de API, incluindo uma IU para explorar e testar operações, diretamente de suas rotas, controladores e modelos.
- [AutoMapper](https://github.com/AutoMapper/AutoMapper): versão 10.1.1
    - Um mapeador de objeto-objeto baseado em convenção em .NET.
- [FluentValidation](https://fluentvalidation.net/): versão 10.2.3
    - Biblioteca de validação para .NET que usa uma interface fluente e expressões lambda para construir regras de validação fortemente tipadas.
- [MySql.EntityFrameworkCore](https://www.nuget.org/packages/MySql.EntityFrameworkCore/): versão 3.1.10
    - Mapeador moderno de banco de dados de objeto para .NET. Ele dá suporte a consultas LINQ, controle de alterações, atualizações e migrações de esquema em banco de dados MySql.
- [ClosedXML](https://github.com/ClosedXML/ClosedXML): versão 0.95.4
    - ClosedXML é uma biblioteca .NET para leitura, manipulação e gravação de arquivos Excel 2007+ (.xlsx, .xlsm). Ele visa fornecer uma interface intuitiva e amigável para lidar com a API OpenXML subjacente.
	
## Como rodar a aplicação :arrow_forward:

### Clonando o projeto e instalando dependências

No terminal, clone o projeto: 

```
git clone https://github.com/pablofsilva91/ceci.git
```

Após clonado, navegue até a raiz do projeto e execute o comando "dotnet build" para compilar o projeto e suas dependências:

```
PS ...\Ceci> dotnet build
```

### Criando banco de dados com o Code First

Code First permite que você defina seu modelo usando C# ou VB.Net classes. 
Para a a migração das classe com o code first, um novo banco de dados deve ser criado. 
Nesse projeto foi criado um novo banco de dados "ceci" utilizando o serviço de banco de dados MySql. 
Para a execução dos comandos as configurações do banco de dados devem ser definidas na seção "ConnectionStrings" no arquivo appsettings.  

```
  "ConnectionStrings": {
    "CeciDatabase": "server=localhost;uid=root;pwd=root;database=ceci;persistsecurityinfo=True"
  }
```

Com o banco de dados criado e as configurações definidas, pode ser utilizado no terminal os comando para adicionar a migração inicial das classes de entidades.
O projeto já possui a migração inicial realizada, então existem duas formas de criar as tabelas no banco de dados para esse projeto:

1. Criando tabelas com a migração inicial do projeto

    Uma vez que o projeto possua a migração inicial já implementada, basta realizar o update na base de dados com o comando "dotnet ef database update".
    Por conta da estrutura do projeto é necessário especificar em qual projeto está a classe de contexto e qual é o projeto de inicialização:

    ```
    dotnet ef database update --project Ceci.Infra.Data --startup-project Ceci.WebApplication
    ```

    Além de criar o modelo de dados, essa migração inicial também irá criar os registros de perfil (basic e administrator) e um usuário vinculado ao perfil "administrator". O perfil desse usuário dará permissão para acesso a funcionalidades que exigem esse perfil, uma vez que para acesso a controllers que pussuem a política "Administrator" faz-se necessário que o usuário tenha perfil "administrator".

    As senhas dos usuários devem ser convertidas para o formato base64 que é necessário para a realização da criptografia. É realizado uma criptografia da senha antes do armazenamento do registro e também a descriptografia no momento da validação do usuário, ou seja, tanto para o cadastro quanto para o login na aplicação, a senha deve ser convertida para base64 antes do envio.

    Dados do usuário registrado pelo code first:

    Email: admin@email.com

    Password: YWRtaW4= (base64 "admin" = "YWRtaW4=")

2. Realizar a migração do zero

    Para criar a migração inicial do zero, é necessário excluir a pasta "Migrations" que consta no projeto "Ceci.Infra.Data". A nova migração pode ser criada com o comando "dotnet ef migrations add [NOME_MIGRACAO]". Por conta da estrutura do projeto é necessário especificar em qual projeto está a classe de contexto e qual é o projeto de inicialização:

    ```
    dotnet ef migrations add InitialMigration --project Ceci.Infra.Data --startup-project Ceci.WebApplication
    ```

    Diferente da criação das tabelas aproveitando a migração já implementada no projeto, essa migração não criará os perfis básicos necessários para o controle de autenticação do projeto e nem o usuário inicial. Esses registros podem ser realizados de forma manual ou pode ser adicionado aproveitando a migração inicial, para isso, adicione esse código no final do método "Up" que consta na classe de migração ("InitialMigration" ou o nome que foi definido na execução do comando) que foi criado após a execução do comando "dotnet ef migrations add":

    ```
           migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Active", 
                    "RegistrationDate", 
                    "Name" },
                values: new object[,]
                {
                    { true, DateTime.Now, "administrator" },
                    { true, DateTime.Now, "basic" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Active",
                                "RegistrationDate",
                                "Name",
                                "Email",
                                "Password",
                                "RoleId",
                                "Validated",
                                "ChangePassword" },
                values: new object[,]
                {
                    { true,
                        DateTime.Now,
                        "Administrator",
                        "admin@email.com",
                        PasswordExtension.EncryptPassword("YWRtaW4="), /*Generate a new encrypted password for the base64 encoded "admin" value (base64 admin = YWRtaW4=)*/
                        1 /*role Administrator*/,
                        true,
                        false},
                });
    ```

    Como apresentado no código acima e também explicado na opção de criação das tabelas aproveitando a migração já implementada, as senhas dos usuários devem ser convertidas para o formato base64 que é necessário para a realização da criptografia. É realizado uma criptografia da senha antes do armazenamento do registro e também a descriptografia no momento da validação do usuário, ou seja tanto para o cadastro quanto para o login na aplicação, a senha deve ser convertida para base64 antes do envio.

    Concluída a etapa de adicionar a migração, executar o comando "dotnet ef database update" para atualizar a base de dados:

    ```
    dotnet ef database update --project Ceci.Infra.Data --startup-project Ceci.WebApplication
    ```

**Alterações nas entidades**

Para novas alterações nas entidades, pode ser executado o comando "dotnet ef migrations add [NOME_MIGRACAO]", que vai adicionar em uma nova migração com as alterações realizadas:

```
dotnet ef migrations add [NOME_MIGRACAO] --project Ceci.Infra.Data --startup-project Ceci.WebApplication
```

Após a criação da migração, executar o comando para atualizar a base de dados:

```
dotnet ef database update --project Ceci.Infra.Data --startup-project Ceci.WebApplication
```

### Rodando a aplicação

Navegue até o projeto WebApplication "Ceci.WebApplication" e execute o comando "dotnet run": 

```
PS ...\Ceci\Ceci.WebApplication> dotnet run
```

O endereço da aplicação ficará disponível no console. Com a URL identificada é possível realizar um teste acessando o swagger da aplicação:

```
https://localhost:[PORTA]/swagger
```

As credenciais para logar e visualizar o swagger estão definidas na seção "SwaggerSettings" no arquivo appsettings.json. Essas credenciais podem ser alteradas ou até mesmo o login ser removido, o conteúdo de apoio para a implementação da funcionalidade pode ser visualizado no tópico Swagger na listagem de Referências [Restrict access to swagger](https://github.com/domaindrivendev/Swashbuckle.WebApi/issues/384).

### Executando os testes

Navegue até o projeto de testes "Ceci.Test" e execute o comando "dotnet test": 

```
PS ...\Ceci\Ceci.Test> dotnet test
```

O resultado dos testes aparecerá no console.

## Referências :newspaper:

Os seguintes artigos, documentações e exemplos foram utilizados como material de apoio para a implementação do projeto:

### Arquitetura

- https://alexalvess.medium.com/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686
- http://www.macoratti.net/18/12/netcore_repo1.htm
- http://www.linhadecodigo.com.br/artigo/3370/entity-framework-4-repositorio-generico.aspx
- https://medium.com/imaginelearning/asp-net-core-3-1-microservice-quick-start-c0c2f4d6c7fa
- https://pradeeploganathan.com/architecture/repository-and-unit-of-work-pattern-asp-net-core-3-1/

### Validações e regras de negócio

- https://docs.fluentvalidation.net/en/latest/aspnet.html
- https://stackoverflow.com/questions/40275195/how-to-set-up-automapper-in-asp-net-core/40275196#40275196
- https://desenvolvedor.ninja/dica-validacao-de-cpf-e-cnpj-no-c/

### Autenticação

- https://jasonwatmore.com/post/2020/05/25/aspnet-core-3-api-jwt-authentication-with-refresh-tokens
- https://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp
- https://balta.io/artigos/aspnetcore-3-autenticacao-autorizacao-bearer-jwt
- https://www.red-gate.com/simple-talk/development/dotnet-development/policy-based-authorization-in-asp-net-core-a-deep-dive/

### Envio de email

- https://www.ryadel.com/en/asp-net-core-send-email-messages-sendgrid-api/
- http://www.macoratti.net/20/08/aspnc_email1.htm

### Execução em background

- https://andyp.dev/posts/hangfire-mysql-asp-net
- https://docs.hangfire.io/en/latest/getting-started/aspnet-core-applications.html
- https://docs.hangfire.io/en/latest/background-methods/writing-unit-tests.html

### Testes

- http://www.macoratti.net/19/10/cshp_unitestmoq1.htm
- https://www.c-sharpcorner.com/article/unit-testing-using-xunit-and-moq-in-asp-net-core/
- https://nelson-souza.medium.com/net-core-fake-data-442fed37718d
- https://code-maze.com/unit-testing-controllers-aspnetcore-moq/

### Swagger

- https://www.c-sharpcorner.com/article/asp-net-core-3-1-web-api-and-swagger/
- https://github.com/domaindrivendev/Swashbuckle.WebApi/issues/384#issuecomment-410117400
- https://stackoverflow.com/a/58972781/9831049

### Importação e manipulação de arquivos

- https://closedxml.readthedocs.io/en/latest/simpleWorkbookExample.html#creating-a-workbook

### Documentação

- https://dev.to/reginadiana/como-escrever-um-readme-md-sensacional-no-github-4509
- https://blog.rocketseat.com.br/como-fazer-um-bom-readme/