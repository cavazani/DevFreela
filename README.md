# 💻 Projeto DevFreela
Projeto foi criado e desenvolvido durante o curso Formação ASP.Net Core do [Luis Dev](https://www.linkedin.com/in/luisdeol/).

O DevFreela é uma API para gerenciar freelancing, permitindo que clientes contratem desenvolvedores. Oferece funcionalidades como cadastro, atualização e consulta de serviços, gerenciamento de perfis, comentários e controle de projetos. Desenvolvido com tecnologias como ASP.NET Core, Arquitetura Limpa, e mais.

O projeto foi desenvolvido como uma WebAPI utilizando .NET 8 e C# com o ASP.NET Core  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" width="20" /> 
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" width="20" />



# 🛠 Tecnologias
 - Swagger
 - Arquitetura Limpa
 - Entity Framework Core
 - Padrão CQRS com Mediator
 - Padrão Repository
 - Padrões de Refatoração
 - FluentValidation
   

## Swagger <img src="https://github.com/user-attachments/assets/87489c25-2723-4788-ad5f-c2cb926265af" width="19" />

Swagger é um framework que facilita o desenvolvimento e a documentação de APIs REST, independentemente da linguagem de programação utilizada. Ele oferece uma interface gráfica que exibe todos os endpoints da API e permite a execução direta de requisições. Além de fornecer uma documentação completa da API, o Swagger também simplifica o consumo de serviços, ajudando a testar e validar os métodos implementados nos controllers da API.

### Swagger DevFreela
![Swagger_Gif](https://github.com/user-attachments/assets/f847caa7-272b-43bb-bba0-62d01af34a63)

---
## Arquitetura Limpa
Arquitetura Limpa é uma abordagem amplamente adotada em projetos .NET, proposta por Robert C. Martin (Uncle Bob). Seu objetivo principal é promover a testabilidade, desacoplamento, coesão e reutilização de código. O foco central dessa arquitetura é o domínio do sistema, seguindo os princípios do Domain-Driven Design (DDD). Embora existam várias variações da Clean Architecture, a essência permanece a mesma.
Estrutura Principal

A arquitetura é organizada em quatro camadas principais:

    - Core: Contém os serviços de domínio, classes, repositórios, interfaces. 
    - Infrastructure: Contém as implementações do repositório e a classe DbContext.
    - Application: Contém as implementações dos Commands, Queries e Validators, além dos, View Models e Input Models.
    - UI/API: Contém os Controllers, Injeção de Dependência, Swagger, SQL-Server DbContext

<div align="center">
    <img src="https://github.com/user-attachments/assets/fd96fecb-7a88-4bce-bd6b-17b15300cccd" width="500px" />    
</div>


---
## Entity Framework Core
Entity Framework Core (EF Core) é, de fato, a principal ferramenta ORM (Object-Relational Mapper) usada para o desenvolvimento com .NET. Ele permite que desenvolvedores interajam com bancos de dados usando código C# em vez de SQL, o que aumenta a produtividade e facilita a manutenção do código. Além disso, ele é open-source, multiplataforma e suporta vários sistemas de banco de dados, como SQL Server, PostgreSQL, MySQL, SQLite, entre outros.

### Benefícios do EF Core:

- <b>Abstração do banco de dados:</b> Ao permitir que as interações com o banco de dados sejam feitas usando objetos e classes, sem a necessidade de escrever SQL manualmente, o EF Core facilita o trabalho de desenvolvimento.
- <b>Multiplataforma:</b> Com o .NET Core, o EF Core tornou-se uma solução multiplataforma, podendo rodar em Windows, Linux e macOS.
- <b>Performance: </b> A cada nova versão, a Microsoft melhora a performance e adiciona novas funcionalidades, como otimizações de consultas, suporte a banco de dados in-memory para testes e funcionalidades específicas como LINQ.

### Conceitos principais:

- <b>Code First:</b> Essa abordagem é usada para definir as entidades diretamente no código. O EF Core depois gera o banco de dados baseado nessas classes e suas configurações. Essa abordagem permite maior controle e flexibilidade na evolução do banco de dados.
- <b>DbContext: </b> O DbContext é o ponto central para a interação entre o código e o banco de dados. Ele é responsável por gerenciar o ciclo de vida das entidades, consultas, e transações de dados. Cada sessão de acesso ao banco de dados é representada por uma instância de DbContext.
- <b>DbSet:</b> O DbSet representa uma coleção de entidades em um contexto específico. Cada DbSet<T> permite executar consultas e operações de manipulação (CRUD) sobre o tipo de entidade T.
- <b>Migrations:</b> As migrations permitem evoluir o esquema do banco de dados ao longo do tempo. Isso é feito com base nas alterações que você realiza nas classes de entidades. As migrations geram scripts SQL automaticamente para refletir essas mudanças no banco de dados.


--- 
## CQRS / MediatR

### Padrão CQRS (Command and Query Responsibility Segregation)

CQRS é um padrão arquitetural que propõe a separação clara entre operações de leitura (Queries) e operações de escrita ou modificação (Commands), promovendo uma maior organização e clareza no código.

    Queries: Responsáveis apenas por buscar dados, sem alterar o estado da aplicação.
    Commands: Responsáveis por modificar o estado do sistema, seja inserindo, atualizando ou excluindo dados.

Essa separação de responsabilidades permite diversas abordagens arquiteturais. Por exemplo, você pode optar por usar o mesmo banco de dados para ambas as operações ou trabalhar com dois bancos de dados distintos, criando dois modelos de dados separados. Um exemplo prático seria usar o SQL Server para operações de leitura e o MongoDB para escrita.

Com a atualização do banco de dados de leitura pode ser feita de forma assíncrona, utilizando eventos capturados em memória ou através de ferramentas de mensageria/event streaming, como RabbitMQ ou Apache Kafka.

Mesmo em um cenário com um único banco de dados, o padrão CQRS traz benefícios como a separação de responsabilidades, facilitando a manutenção e tornando o código mais organizado e limpo.

<div align="center">
    <img src="https://github.com/user-attachments/assets/ce9817f5-5fcb-4632-8d55-a3be022dffa7" width="800px" />    
</div>

### Sobre o MediatR
MediatR é uma biblioteca popular em .NET que implementa o padrão de design Mediator, facilitando o desacoplamento na comunicação entre objetos e promovendo uma arquitetura mais limpa.

- Desacoplamento por meio de mediadores: Ao invés dos controladores (Controllers) conhecerem diretamente os manipuladores (Handlers) de comandos ou consultas, o MediatR atua como um mediador, decidindo qual Handler será acionado.
- Comunicação indireta: Objetos se comunicam por meio do MediatR, que gerencia o fluxo de solicitações, comandos, eventos ou mensagens de maneira centralizada.

Principais interfaces do MediatR:

- IRequest: A classe que representa os modelos de entrada (para comandos) ou de consulta deve implementar essa interface.
        Nos Commands, ela geralmente representa o modelo de entrada de dados da aplicação.
        Nas Queries, a classe é construída com base nos parâmetros de URL ou Query Strings.

- IRequestHandler: Classe responsável por processar as instâncias que implementam a IRequest.
        É uma boa prática criar um Handler por comando ou consulta, evitando classes grandes e com muitas responsabilidades.

- IMediator: Interface usada para publicar um comando ou consulta para o Handler correspondente. 
    O IMediator atua como intermediário entre os objetos.

Configuração do MediatR:

Para configurar o MediatR no seu projeto, adicione a seguinte linha no seu arquivo Startup.cs ou Program.cs:

    csharp
    
    services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<T>());

---
## Padrão Repository
O Padrão Repository é amplamente utilizado para abstrair o acesso aos dados, permitindo desacoplar a lógica de persistência do resto da aplicação.

- Abstração do acesso a dados: Com o uso do padrão Repository, os detalhes de implementação de acesso aos dados (como consultas SQL ou APIs de banco de dados) são abstraídos, resultando em um código mais limpo e flexível.

- Desacoplamento: Quando usado em conjunto com interfaces, o padrão facilita o desacoplamento, possibilitando que a lógica de acesso a dados possa ser substituída ou alterada sem impactar outras camadas da aplicação.

- Domínio no DDD: No contexto do Domain-Driven Design (DDD), o Repository é um componente de domínio que gerencia o acesso aos objetos persistidos, sem se preocupar com a origem ou o tipo de armazenamento dos dados (banco de dados, serviços externos, etc.).


---
## Padrões de Refatoração

Refatoração é o processo de melhorar a estrutura de um projeto sem alterar seu comportamento funcional. É uma prática essencial para manter a saúde do código e sua manutenibilidade ao longo do tempo.

- Refatoração é inevitável: Como desenvolvedores, não podemos evitar a necessidade de refatorar código. Muitas vezes, encontramos código legado ou mal projetado, e a primeira reação é culpar os desenvolvedores anteriores. No entanto, o verdadeiro desafio é: estamos apenas aumentando o problema ou estamos agindo para melhorá-lo?
  
- A importância de refatorar com responsabilidade: É fundamental entender as mecânicas de alteração de software. De acordo com o livro Trabalho Eficaz com Código Legado, existem quatro motivos principais para alterar um software:
  
       - Inclusão de uma nova funcionalidade.
       - Correção de um bug.
       - Melhoria do design ou estrutura.
       - Otimização de recursos (memória, processamento, etc.).

- Medo de código legado: Código legado é um dos maiores temores dos desenvolvedores. Alterá-lo com segurança exige conhecer padrões de refatoração. Alterar código crítico sem as melhores práticas pode gerar um sistema mais difícil de manter, menos legível e com mais bugs.

### Refatorando com o Padrão Repository

Um exemplo de como aplicar padrões de refatoração é o uso do Padrão Repository. O Repository permite desacoplar o acesso a dados do restante da aplicação, resultando em um código mais limpo e de fácil manutenção.

Para aplicar esse padrão, siga este fluxo:

    Extrair Método: Identifique e migre o código responsável pelo acesso a dados para um método dedicado.
    Extrair Classe: Migre o método extraído para uma classe específica que se encarregue do acesso a dados.
    Extrair Interface: Crie uma interface a partir da classe extraída, definindo um contrato claro para o repositório.
    Substituição: Use injeção de dependência para passar a interface nas classes que precisam acessar os dados, eliminando dependências diretas e tornando o código mais flexível e fácil de modificar.


---
## FluentValidation
### O que é Fluent Validation
FluentValidation é uma biblioteca poderosa usada para validar objetos em aplicações .NET, sendo particularmente útil para validar modelos de entrada, como Commands ou Input Models.

- Instalação: O FluentValidation é adicionado ao projeto através do pacote FluentValidation.AspNetCore.
- Validação por classe: Para cada modelo de entrada a ser validado, uma classe de validação é criada, onde as regras de validação são definidas.

Como utilizar o FluentValidation:

- Configuração global: O FluentValidation pode ser configurado globalmente na aplicação.
- Criação de uma classe validadora: Crie uma classe que herde de AbstractValidator<T>, onde T é o tipo do modelo que será validado.
- Definir regras de validação: No construtor da classe, implemente as regras de validação utilizando o método RuleFor.

    Validação manual: Se preferir um controle mais manual, o FluentValidation também permite que você injete o objeto IValidator<T> para chamar o método Validate e verificar o resultado através da propriedade IsValid.

Funcionalidades do FluentValidation:

    Validações de propriedades simples (ex.: strings, números).
    Validações de propriedades complexas (ex.: objetos).
    Validação de coleções (listas).
    Suporte a múltiplos validadores para a mesma classe, permitindo maior flexibilidade na validação de diferentes cenários.

Métodos de validação mais utilizados:

    <NotNull, NotEmpty: Valida se o valor não é nulo ou vazio.
    Equal, NotEqual: Verifica se o valor é igual ou diferente de um valor especificado.
    Length, MaxLength, MinLength: Define limites de tamanho para strings.
    LessThan, LessThanOrEqualTo, GreaterThan, GreaterThanOrEqualTo: Valida se o valor está dentro de uma faixa numérica.
    Must: Permite a definição de regras personalizadas com base em uma condição.
    EmailAddress: Valida se o valor é um endereço de e-mail válido.
    CreditCard: Verifica se o valor é um número de cartão de crédito válido.
    IsInEnum: Verifica se o valor está contido em um enum.
