## Sistema "Meu Patrimônio"

Sistema para gerenciar patrimônios de uma organização.

## Requisitos

### Patrimônio

* Campos:
    * Nome - obrigatório
    * MarcaId - obrigatório
    * ModeloId - obrigatório
    * Descrição
    * Nº do tombo

* Endpoints:
    * GET patrimonios - Obter todos os patrimônios
    * GET patrimonios/{marcaId} - Obter todos os patrimônios de uma determinada marca
    * GET patrimonios/{modeloId} - Obter todos os patrimônios de um determinado modelo
    * GET patrimonio/{id} - Obter um patrimônio por ID
    * POST patrimonio - Inserir um novo patrimônio
    * PUT patrimonio/{id} - Alterar os dados de um patrimônio
    * DELETE patrimonio/{id} - Excluir um patrimônio

* Regras:
    * O nº do tombo deve ser gerado automaticamente pelo sistema, e não pode ser alterado pelos usuários.

### Marca

* Campos:
    * Nome - obrigatório

* Endpoints:
    * GET marcas - Obter todas as marcas
    * GET marca/{id} - Obter uma marca por ID
    * POST marca - Inserir uma nova marca
    * PUT marca/{id} - Alterar os dados de uma marca
    * DELETE marca/{id} - Excluir uma marca

* Regras:
    * Não deve permitir a existência de duas marcas com o mesmo nome.

### Modelo

* Campos:
    * Nome - obrigatório

* Endpoints:
    * GET modelos - Obter todos os modelos
    * GET modelos/{marcaId} - Obter todos os modelos de uma determinada marca
    * GET modelo/{id} - Obter um modelo por ID
    * POST modelo - Inserir um novo modelo
    * PUT modelo/{id} - Alterar os dados de um modelo
    * DELETE modelo/{id} - Excluir um modelo

* Regras:
    * Não deve permitir a existência de dois modelos com o mesmo nome para uma marca.
	
## Projeto

### Banco de dados

* Foi criado um banco, schema, login e usuário de nome 'meupatrimonio'

* Foram criadas as tabelas: 
	* MARCA(Id, Nome)
	* MODELO(Id, MarcaId, Nome) 
	* PATRIMONIO(Id, MarcaId, ModeloId, Nome, Descricao, Tombo)
	
* Foi criada a sequência 'SEQ_PATRIMONIO_TOMBO' para atribuir automaticamente o número do tombo no patrimonio

## Ferramentas e técnicas adotadas

* Microsoft SQL Server Express 2017
* Microsoft Visual Studio Community 2017 
* .NET Framework 4.6.1
* Linguagem de programação C#
* Arquitetura do projeto em Domain Driven Design (DDD)
* Service API REST em APS.NET Web API 2 
* Injeção de dependência usando Unity
* Conversão de classes DTO para classes de domínio usando AutoMapper
* Mapeamento de objeto relacional (ORM) usando Entity Framework 6
* Alguns testes unitários usando Microsoft Unit Testing

## Solução

### O início

O projeto teve a intenção de ser desenvolvido sobre uma estrutura escalável, flexível, adaptável e de alta produtividade. 
Considerando estas premissas, a solução foi criar o projeto utilizando a arquitetura DDD, implementando classes básicas e autiliares, 
abstraídas para prover o melhor desempenho possível ao criar novas classes ou fazer manutenções no código.

O projeto começou com a criação do modelo relacional no banco de dados. Para solucionar o problema da numeração automática do tomo
do patrimônio, foi criada uma sequencia, ligada diretamente com a coluna 'Tomo' da tabela 'Patrimonio'.

Em seguida, foi elaborada a estrutura do DDD. Cada classe básica (Base) contém métodos para resolver ações básicas como Cadastrar, Editar, Excluir, Buscar por Id, Listar e Listar com Filtros.


### Validações

Cada entidade tem uma classe para validação. Esta classe consegue distinguir validação de atributos e validação de regras de negócio, bem como para qual ação deve ser validada. As validações são executadas apenas quando existem itens de validação no objeto de validação correspondente e são sempre executadas antes de alterar um dado na fonte de dados. As validações que falharam são colocadas em uma lista que pode ser facilmente acessada pela camada de apresentação através de uma Exception específica, a ValidacaoException, que contém como propriedade essa lista de validações inválidas. Com isso, o responsável pela camada de apresentação pode decidir apresentar todas as mensagens ou apenas uma por vez.

### 