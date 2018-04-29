CREATE DATABASE meupatromonio;
GO

USE meupatromonio;
GO

CREATE LOGIN meupatromonio WITH PASSWORD = 'plenodotnetsigma';
GO

CREATE USER meupatromonio FOR LOGIN meupatromonio;
GO