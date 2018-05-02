# Título do Projeto
Sistema para Controle de Patrimônio

### Pré-requisitos
Visual Studio 2017
SQL Server 2016

##Configuração
	Configurar a "connectionStrings" no arquivo "Web.config";
		1- Data Source = Endereço do Servidor; 
		2- Initial Catalog = Nome do Banco de Dados;
		3- User Id = Usuário do servidor para acesso ao banco de dados;
		4- Password = Senha usuário do servidor para acesso ao banco de dados;

### URLs Válidas

	PATRIMÔNIOS
	
		GET patrimonios - http://www.example.gov/api/v1/Patrimonios
		GET patrimonios/{marcaId} - http://www.example.gov/api/v1/Patrimonios/{MarcaId}/Marca
		GET patrimonios/{modeloId} - http://www.example.gov/api/v1/Patrimonios/{ModeloId}/Modelo
		GET patrimonio/{id} - http://www.example.gov/api/v1/Patrimonios/{id}
		POST patrimonio - http://www.example.gov/api/v1/Patrimonios
		PUT patrimonio/{id} - http://www.example.gov/api/v1/Patrimonios/{id}
		DELETE patrimonio/{id} - http://www.example.gov/api/v1/Patrimonios/{id}
	
	MARCA
	
		GET marcas - http://www.example.gov/api/v1/Marcas
		GET marca/{id} - http://www.example.gov/api/v1/Marcas/{id}
		POST marca - http://www.example.gov/api/v1/Marcas
		PUT marca/{id} - http://www.example.gov/api/v1/Marcas/{id}
		DELETE marca/{id} - http://www.example.gov/api/v1/Marcas/{id}
		
	MODELO
	
		GET modelos - http://www.example.gov/api/v1/Modelos
		GET modelos/{marcaId} - http://www.example.gov/api/v1/Modelos/{MarcaId}/Marca
		GET modelo/{id} - http://www.example.gov/api/v1/Modelos/{id}
		POST modelo - http://www.example.gov/api/v1/Modelos
		PUT modelo/{id} - http://www.example.gov/api/v1/Modelos/{id}
		DELETE modelo/{id} - http://www.example.gov/api/v1/Modelos/{id}

## Construído com

Linguagem C#
Banco de dados SQL Server
ASP.NET Web Api
Swagger
Endpoints no formato JSON

## Versão
1.0.0.0

## Autor
Bruno Milani