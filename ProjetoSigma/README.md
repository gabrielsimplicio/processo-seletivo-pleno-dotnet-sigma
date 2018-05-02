# Sigma - Projeto gerenciamento de patrimônios.

Linguagem: c#

IDE: Visual Studio 2017 - BackEnd; Visual Code FrondEnd

API: foi construida na tecnologia ASP.NET Web Api

ORM: Entity Framework é uso de Fluent API

Test Unitario

Injeção de Dependencia foi utilizado: SimpleInject.

Foi usado AutoMapper para mapear models > domain vice-versa.

O projeto contem: DDD, Repository Pattern, Unit Of Work

SWAGGER: Utilizado, URL's:

    - Marca: http://localhost:53447/swagger/    
    - Modelo: http://localhost:58481/swagger/    
    - Patrimônio: http://localhost:52928/swagger/
    
Projeto está organizado com pastas
  - Domain, Domain.Service
  - Services.API
  - Infra, CrossCutting, CrossCutting.Ioc
  - Applicaion
  - Presentation ( utilizado angular como front )
  
  
  API Patrimônio foi adotado: buscar todos patrimônio pelo modelo ou marca, usando routas simples para entendimento
  como por exemplo: 
  
    api/patrimonio/{marcaId}/marca 
    api/patrimonio/{modeloId}/modelo


Patrimonio tombo, aplicação está gerando toda vez que o metodo Add() é invocado pelo request, 
coloquei um simples random caractes utilizando 'ano.random caractes' obs: usuario não tem como alterar valor tombo gerado,
pois Class Domain e ViewModels estão protegido.


FrontEnd é Angular sei que não é item obrigatório mais eu fiz :D

resumidamente é isso desculpa se esquecer de algo.