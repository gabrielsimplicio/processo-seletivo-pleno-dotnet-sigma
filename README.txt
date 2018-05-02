
Foi desenvolvido uma aplicação ASP.NET Web Api que fará uso de um CRUD e reutilizável baseado no Entity Framework 4.5
( Code-First, API DBcontext, Data Annotations, Validações, Mapeamentos de banco de dados "SQL Server" ).


- Estrutura de pasta do projeto
  . DBContext -> Classe PatrimonioContext.cs possui acesso a uma base de dados para a realização de operações de consulta, inclusão, alteração e exclusão de informações
  . Models/Entities -> Classes Marca, Modelo e Patrimonio
  . Models/EntitiesMap -> Classes de mapeamento com banco de dados
  . SQL -> Contém scripts de banco de dados para criação de tabelas no banco de dados SQL Server
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

- Patrimônio
	GET patrimonios - Obter todos os patrimônios
	GET patrimonios/{marcaId} - Obter todos os patrimônios de uma determinada marca
	GET patrimonios/{modeloId} - Obter todos os patrimônios de um determinado modelo
	GET patrimonio/{id} - Obter um patrimônio por ID
	POST patrimonio - Inserir um novo patrimônio
	PUT patrimonio/{id} - Alterar os dados de um patrimônio
	DELETE patrimonio/{id} - Excluir um patrimônio

