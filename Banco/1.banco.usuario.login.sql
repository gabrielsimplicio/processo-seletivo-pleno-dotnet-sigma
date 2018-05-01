CREATE DATABASE meupatrimonio;
GO

USE meupatrimonio;
GO

CREATE SCHEMA meupatrimonio;
GO

CREATE LOGIN meupatrimonio WITH PASSWORD = 'plenodotnetsigma';
GO

CREATE USER meupatrimonio FOR LOGIN meupatrimonio WITH DEFAULT_SCHEMA = meupatrimonio;
GO

GRANT execute,select,insert,update,delete TO MEUPATRIMONIO
GO