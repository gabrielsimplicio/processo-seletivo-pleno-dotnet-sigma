
Foi desenvolvido uma aplica��o ASP.NET Web Api que far� uso de um CRUD e reutiliz�vel baseado no Entity Framework 4.5
( Code-First, API DBcontext, Data Annotations, Valida��es, Mapeamentos de banco de dados "SQL Server" ).


- Estrutura de pasta do projeto
  . DBContext -> Classe PatrimonioContext.cs possui acesso a uma base de dados para a realiza��o de opera��es de consulta, inclus�o, altera��o e exclus�o de informa��es
  . Models/Entities -> Classes Marca, Modelo e Patrimonio
  . Models/EntitiesMap -> Classes de mapeamento com banco de dados
  . SQL -> Cont�m scripts de banco de dados para cria��o de tabelas no banco de dados SQL Server
  . ViewModel -> Criou-se uma classe ViewModel para a classe Patrimonio


Funcionalidades da Controller: 
- Marca 
	GET marcas - Obter todas as marcas
	GET marca/{id} - Obter uma marca por ID
	POST marca - Inserir uma nova marca
	PUT marca/{id} - Alterar os dados de uma marca
	DELETE marca/{id} - Excluir uma marca

- Modelo
	GET modelos - Obter todos os modelos
	GET modelos/{marcaId} - Obter todos os modelos de uma determinada marca
	GET modelo/{id} - Obter um modelo por ID
	POST modelo - Inserir um novo modelo
	PUT modelo/{id} - Alterar os dados de um modelo
	DELETE modelo/{id} - Excluir um modelo

- Patrim�nio
	GET patrimonios - Obter todos os patrim�nios
	GET patrimonios/{marcaId} - Obter todos os patrim�nios de uma determinada marca
	GET patrimonios/{modeloId} - Obter todos os patrim�nios de um determinado modelo
	GET patrimonio/{id} - Obter um patrim�nio por ID
	POST patrimonio - Inserir um novo patrim�nio
	PUT patrimonio/{id} - Alterar os dados de um patrim�nio
	DELETE patrimonio/{id} - Excluir um patrim�nio

