# Sistema "Meu Patrimônio"

Gerenciamento de patromônio












## O desafio

Crie uma Web API REST para o gerenciamento de patrimônios de uma empresa

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

### Requisitos técnicos

* Deve-se usar o C#
* Os dados devem ser salvos no SQL Server
* Deve-se usar o ASP.NET Web Api ou o ASP.NET Core Web Api
* Deve-se usar o Swagger
* Os endpoints devem utilizar o formato JSON
* A sua aplicação deve conter um arquivo README explicando o funcionamento e a solução adotada na sua implementação do desafio

### Observações/Dicas

* Não limite-se às funcionalidades acima. Qualquer outra feature extra é bem-vinda.
* A arquitetura é por sua conta.
* Coloque um script de criação do banco de dados junto ao projeto.
* Não é necessária a criação de telas.

## Critérios de avaliação

* Organização do código
* Organização da estrutura
* Arquitetura desenvolvida
* Documentação do projeto (readme)

## Procedimento

* Faça um fork do projeto https://github.com/gabrielsimplicio/processo-seletivo-pleno-dotnet-sigma
* Ao finalizar a sua aplicação, crie um pull request no projeto de origem.

## Prazo
* O prazo para criar pull requests é até o dia 02/05/2018, às 12h.

### Dê o seu melhor!
### Boa prova! ;)