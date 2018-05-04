## Gerenciador de Patrimonios


### Marca

##### Atributos:

- MarcaId (int)(obrigatorio)
- Nome (string)(obrigatorio)

 
##### Endpoints:


- GET marcas - Obter todas as marcas
 <br> Retorna Todas as marcas cadastradas no banco de dados.

- GET marcas/id - Obter uma marca por ID
 <br> Retorna marca expecifica cadastrada no banco de dados.
 
- POST marcas - Inserir uma marca
  <br> Cadastra uma unica marca por vez, não podendo cadastrar o nome de uma marca ja inclusa no banco de dados,
       caso ocorra o usuario sera informado com a seguinte mensagem "Marca já existe".
  <br> Caso usuario deixe o nome da marca em branco sera informado com a seguinte mensagem "Nome da marca nao pode ser nulo ou vazio".
  <br> Caso ocorra algum erro sistemico o usuario sera informado com a seguinte mensagem <>"Falha ao salvar a marca".</span>
- PUT marcas/id - Alterar os dados de uma marca
  <br> Cadastra uma unica marca por vez, não podendo cadastrar o nome de uma marca ja inclusa no banco de dados,
       caso ocorra o usuario sera informado com a seguinte mensagem "Marca já existe".
  <br> Caso usuario deixe o nome da marca em branco sera informado com a seguinte mensagem "Nome da marca nao pode ser nulo ou vazio".
  <br> Caso ocorra algum erro sistemico o usuario sera informado com a seguinte mensagem <>"Falha ao alterar a marca".</span>
- DELETE marcas/id - Excluir uma marca
 <br> Exclui uma marca expecifica cadastradas no banco de dados, sendo obrigatorio informar o atributo MarcaId.


---
### Modelo

##### Atributos:

- ModeloId (int)(obrigatorio)
- Nome (string)(obrigatorio)
- MarcaId (int)(obrigatorio)
 
##### Endpoints:

- GET modelos - Obter todas os modelos
 <br> Retorna Todos os modelos cadastrados no banco de dados.

- GET modelos/id - Obter um modelo por ID
 <br> Retorna modelo expecifico cadastrado no banco de dados.

- GET marcas/marcaId/modelos - Obter todos os modelos por Marca
 <br> Retorna modelos por marca cadastrado no banco de dados.
 
- POST modelos - Inserir um modelo
  <br> Cadastra um unico modelo por vez, não podendo cadastrar o nome de um modelo mais de uma vez para a mesma marca ja inclusa no banco de dados,
       caso ocorra o usuario sera informado com a seguinte mensagem "Modelo já existe".
  <br> Caso usuario deixe o nome do modelo em branco sera informado com a seguinte mensagem "Nome do modelo nao pode ser nulo ou vazio".
  <br> Caso usuario deixe a MarcaId em branco sera informado com a seguinte mensagem "MarcaId nao pode ser nulo ou vazio".
  <br> Caso ocorra algum erro sistemico o usuario sera informado com a seguinte mensagem <>"Falha ao salvar a marca".</span>

-  PUT modelos/id - Alterar os dados de um modelo
  <br> Cadastra um unico modelo por vez, não podendo cadastrar o nome de um modelo mais de uma vez para a mesma marca ja inclusa no banco de dados,
       caso ocorra o usuario sera informado com a seguinte mensagem "Modelo já existe".
  <br> Caso usuario deixe o nome do modelo em branco sera informado com a seguinte mensagem "Nome do modelo nao pode ser nulo ou vazio".
  <br> Caso usuario deixe a MarcaId em branco sera informado com a seguinte mensagem "MarcaId nao pode ser nulo ou vazio".
  <br> Caso ocorra algum erro sistemico o usuario sera informado com a seguinte mensagem <>"Falha ao salvar a marca".</span>

- DELETE modelos/id - Excluir um modelo
 <br> Exclui um modelo expecifico cadastradas no banco de dados, sendo obrigatorio informar o atributo ModeloId.


---
### Patrimonio

##### Atributos:

- PatrimonioId (int)(obrigatorio)
- Nome (string)(obrigatorio)
- MarcaId (int)(obrigatorio)
- ModeloId (int)(obrigatorio)
- Descricao (string)(opcional)
- NumeroTombo (Guid)(uniqueidentifier)(obrigatorio)
 
##### Endpoints:

- GET patrimonios - Obter todos os patrimonios
 <br> Retorna Todos os patrimonios cadastrados no banco de dados.

- GET patrimonios/id - Obter um patrimonios por ID
 <br> Retorna patrimonios expecifico cadastrado no banco de dados.

- GET marcas/marcaId/patrimonios - Obter todos as patrimonios por Marca
 <br> Retorna patrimonios por marca cadastrado no banco de dados.

- GET modelos/modeloId/patrimonios - Obter todos os patrimonios por Modelo
 <br> Retorna patrimonios por modelo cadastrado no banco de dados.
 
- POST patrimonios - Inserir um patrimonios
  <br> Cadastra um unico patrimonio por vez.
  <br> Caso usuario deixe o nome do patrimonio em branco sera informado com a seguinte mensagem "Nome do patrimonio nao pode ser nulo ou vazio".
  <br> Caso usuario deixe a MarcaId em branco sera informado com a seguinte mensagem "MarcaId nao pode ser nulo ou vazio".
  <br> Caso usuario deixe o ModeloId em branco sera informado com a seguinte mensagem "ModeloId nao pode ser nulo ou vazio".
  <br> Caso ocorra algum erro sistemico o usuario sera informado com a seguinte mensagem <>"Falha ao salvar a marca".</span>

-  PUT patrimonios/id - Alterar os dados de um patrimonios
  <br> Cadastra um unico patrimonio por vez.
  <br> Caso usuario deixe o nome do patrimonio em branco sera informado com a seguinte mensagem "Nome do patrimonio nao pode ser nulo ou vazio".
  <br> Caso usuario deixe a MarcaId em branco sera informado com a seguinte mensagem "MarcaId nao pode ser nulo ou vazio".
  <br> Caso usuario deixe o ModeloId em branco sera informado com a seguinte mensagem "ModeloId nao pode ser nulo ou vazio".
  <br> Caso ocorra algum erro sistemico o usuario sera informado com a seguinte mensagem <>"Falha ao salvar a marca".</span>

- DELETE patrimonios/id - Excluir um patrimonios
 <br> Exclui um patrimonios expecifico cadastradas no banco de dados, sendo obrigatorio informar o atributo PatrimonioId.
---
#### Observação: O número do tombo deve ser gerado automaticamente pelo sistema, e não pode ser alterado pelos usuários.



---

### Tecnologias


- Visual Studio 2017 
- Linguagem C#
- ASP.NET Web Api 2
- Entity Framework Migrations
- DDD (Domain Driven Design)
- AutoMapper
- IOC
- Unity WebApi
- Documentação com Swagger
- Endpoints no formato JSON
- Github
---


## Utilização

- Clone ou baixe o repositório.
- Execute a aplicação  
- A pagina inicial do Swagger Gerenciador de Patrimonios ira abrir.
- Clique em Marcas e logo em seguida execute (GET marcas) para obter todas as marcas, 
 <br> dessa fora o Entity Framework atraves do  "Database.SetInitializer" ira criar as tabelas,ralações e inserções em 
 <br> todas as tabelas para melhor experiencia do usuario, sendo assim não sera necessário cadastrar uma Marca e um Modelo para criar um Patrominio.