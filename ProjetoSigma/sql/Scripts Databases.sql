CREATE DATABASE ProjetoSigma
GO

USE ProjetoSigma

CREATE TABLE Marca (
    Id int NOT NULL IDENTITY,
    Nome varchar (255) NOT NULL,
    CONSTRAINT [PK_dbo.Marca] PRIMARY KEY (Id)
);

CREATE TABLE Modelo (
    Id int NOT NULL IDENTITY,
    Nome [varchar](255) NOT NULL,
    CONSTRAINT [PK_dbo.Modelo] PRIMARY KEY (Id)
);

CREATE TABLE Patrimonio (
    Id int NOT NULL IDENTITY,
    Nome varchar (255) NOT NULL,
    Descricao varchar(255),
    Tombo varchar (255),
    ModeloId int NOT NULL,
    MarcaId int NOT NULL,
    CONSTRAINT [PK_dbo.Patrimonio] PRIMARY KEY (Id)
);

CREATE UNIQUE INDEX [IX_Nome] ON [dbo].[Marca]([Nome])
CREATE UNIQUE INDEX [IX_Nome] ON [dbo].[Modelo]([Nome])
CREATE INDEX [IX_ModeloId] ON [dbo].[Patrimonio]([ModeloId])
CREATE INDEX [IX_MarcaId] ON [dbo].[Patrimonio]([MarcaId])


ALTER TABLE [dbo].[Patrimonio] ADD CONSTRAINT [FK_dbo.Patrimonio_dbo.Marca_MarcaId] FOREIGN KEY ([MarcaId]) REFERENCES [dbo].[Marca] ([Id])
ALTER TABLE [dbo].[Patrimonio] ADD CONSTRAINT [FK_dbo.Patrimonio_dbo.Modelo_ModeloId] FOREIGN KEY ([ModeloId]) REFERENCES [dbo].[Modelo] ([Id])
