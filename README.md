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
	
* Foi criada a sequencia 'SEQ_PATRIMONIO_TOMBO' para atribuir automaticamente o número do tombo no patrimonio

