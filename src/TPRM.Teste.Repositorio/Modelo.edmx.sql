
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/13/2018 22:06:28
-- Generated from EDMX file: C:\Users\ramse\Desktop\Prova da Bernhoeft (SAP) v2\TPRM.Teste.Repositorio\Modelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SAP];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AcaoPermissao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Permissao] DROP CONSTRAINT [FK_AcaoPermissao];
GO
IF OBJECT_ID(N'[dbo].[FK_FuncionalidadePermissao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Permissao] DROP CONSTRAINT [FK_FuncionalidadePermissao];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilPermissao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Permissao] DROP CONSTRAINT [FK_PerfilPermissao];
GO
IF OBJECT_ID(N'[dbo].[FK_FuncionalidadeAcao_Acao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FuncionalidadeAcao] DROP CONSTRAINT [FK_FuncionalidadeAcao_Acao];
GO
IF OBJECT_ID(N'[dbo].[FK_FuncionalidadeAcao_Funcionalidade]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FuncionalidadeAcao] DROP CONSTRAINT [FK_FuncionalidadeAcao_Funcionalidade];
GO
IF OBJECT_ID(N'[dbo].[FK_FuncionalidadeModulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Funcionalidade] DROP CONSTRAINT [FK_FuncionalidadeModulo];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioPerfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_UsuarioPerfil];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteEstacionamento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Estacionamento] DROP CONSTRAINT [FK_ClienteEstacionamento];
GO
IF OBJECT_ID(N'[dbo].[FK_CancelaEstacionamento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cancela] DROP CONSTRAINT [FK_CancelaEstacionamento];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioCancela]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_UsuarioCancela];
GO
IF OBJECT_ID(N'[dbo].[FK_MovimentacaoUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movimentacao] DROP CONSTRAINT [FK_MovimentacaoUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetenciaCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Competencia] DROP CONSTRAINT [FK_CompetenciaCliente];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetenciaMovimentacao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Competencia] DROP CONSTRAINT [FK_CompetenciaMovimentacao];
GO
IF OBJECT_ID(N'[dbo].[FK_MovimentacaoCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movimentacao] DROP CONSTRAINT [FK_MovimentacaoCliente];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Acao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Acao];
GO
IF OBJECT_ID(N'[dbo].[Funcionalidade]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Funcionalidade];
GO
IF OBJECT_ID(N'[dbo].[Modulo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Modulo];
GO
IF OBJECT_ID(N'[dbo].[Perfil]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perfil];
GO
IF OBJECT_ID(N'[dbo].[Permissao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permissao];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO
IF OBJECT_ID(N'[dbo].[Movimentacao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movimentacao];
GO
IF OBJECT_ID(N'[dbo].[Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cliente];
GO
IF OBJECT_ID(N'[dbo].[Estacionamento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estacionamento];
GO
IF OBJECT_ID(N'[dbo].[Cancela]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cancela];
GO
IF OBJECT_ID(N'[dbo].[Competencia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Competencia];
GO
IF OBJECT_ID(N'[dbo].[FuncionalidadeAcao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FuncionalidadeAcao];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Acao'
CREATE TABLE [dbo].[Acao] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(50)  NOT NULL,
    [Texto] nvarchar(50)  NULL
);
GO

-- Creating table 'Funcionalidade'
CREATE TABLE [dbo].[Funcionalidade] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(50)  NOT NULL,
    [Texto] nvarchar(50)  NOT NULL,
    [Controlador] nvarchar(50)  NOT NULL,
    [Acao] nvarchar(50)  NULL,
    [Ordem] int  NOT NULL,
    [Status] int  NOT NULL,
    [ModuloId] int  NOT NULL
);
GO

-- Creating table 'Modulo'
CREATE TABLE [dbo].[Modulo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(50)  NOT NULL,
    [Area] nvarchar(50)  NOT NULL,
    [Ordem] int  NOT NULL,
    [Status] int  NOT NULL
);
GO

-- Creating table 'Perfil'
CREATE TABLE [dbo].[Perfil] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(80)  NOT NULL
);
GO

-- Creating table 'Permissao'
CREATE TABLE [dbo].[Permissao] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PerfilId] int  NOT NULL,
    [FuncionalidadeId] int  NOT NULL,
    [AcaoId] int  NOT NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(80)  NOT NULL,
    [CPF] nvarchar(18)  NOT NULL,
    [Login] nvarchar(80)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Senha] nvarchar(50)  NOT NULL,
    [DataHoraLogin] datetime  NULL,
    [Status] int  NOT NULL,
    [PerfilId] int  NOT NULL,
    [CancelaId] int  NULL
);
GO

-- Creating table 'Movimentacao'
CREATE TABLE [dbo].[Movimentacao] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PlacaCarro] nvarchar(max)  NOT NULL,
    [Marca] nvarchar(80)  NOT NULL,
    [Modelo] nvarchar(80)  NOT NULL,
    [Ticket] nvarchar(10)  NOT NULL,
    [DataHoraEntrada] datetime  NOT NULL,
    [DataHoraSaida] datetime  NULL,
    [TipoMovimentacao] int  NOT NULL,
    [UsuarioId] int  NOT NULL,
    [ClienteId] int  NOT NULL
);
GO

-- Creating table 'Cliente'
CREATE TABLE [dbo].[Cliente] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(80)  NOT NULL,
    [CNPJ] nvarchar(18)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Estacionamento'
CREATE TABLE [dbo].[Estacionamento] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(80)  NOT NULL,
    [Endereco] nvarchar(80)  NOT NULL,
    [QtdVagas] int  NOT NULL,
    [ClienteId] int  NOT NULL
);
GO

-- Creating table 'Cancela'
CREATE TABLE [dbo].[Cancela] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [EstacionamentoId] int  NOT NULL
);
GO

-- Creating table 'Competencia'
CREATE TABLE [dbo].[Competencia] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Valor] decimal(10,2)  NOT NULL,
    [Pago] bit  NOT NULL,
    [Mes] int  NOT NULL,
    [Ano] int  NOT NULL,
    [ClienteId] int  NOT NULL,
    [MovimentacaoId] int  NOT NULL
);
GO

-- Creating table 'FuncionalidadeAcao'
CREATE TABLE [dbo].[FuncionalidadeAcao] (
    [Acoes_Id] int  NOT NULL,
    [FuncionalidadeAcao_Acao_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Acao'
ALTER TABLE [dbo].[Acao]
ADD CONSTRAINT [PK_Acao]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Funcionalidade'
ALTER TABLE [dbo].[Funcionalidade]
ADD CONSTRAINT [PK_Funcionalidade]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Modulo'
ALTER TABLE [dbo].[Modulo]
ADD CONSTRAINT [PK_Modulo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Perfil'
ALTER TABLE [dbo].[Perfil]
ADD CONSTRAINT [PK_Perfil]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Permissao'
ALTER TABLE [dbo].[Permissao]
ADD CONSTRAINT [PK_Permissao]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Movimentacao'
ALTER TABLE [dbo].[Movimentacao]
ADD CONSTRAINT [PK_Movimentacao]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [PK_Cliente]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Estacionamento'
ALTER TABLE [dbo].[Estacionamento]
ADD CONSTRAINT [PK_Estacionamento]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cancela'
ALTER TABLE [dbo].[Cancela]
ADD CONSTRAINT [PK_Cancela]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Competencia'
ALTER TABLE [dbo].[Competencia]
ADD CONSTRAINT [PK_Competencia]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Acoes_Id], [FuncionalidadeAcao_Acao_Id] in table 'FuncionalidadeAcao'
ALTER TABLE [dbo].[FuncionalidadeAcao]
ADD CONSTRAINT [PK_FuncionalidadeAcao]
    PRIMARY KEY CLUSTERED ([Acoes_Id], [FuncionalidadeAcao_Acao_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AcaoId] in table 'Permissao'
ALTER TABLE [dbo].[Permissao]
ADD CONSTRAINT [FK_AcaoPermissao]
    FOREIGN KEY ([AcaoId])
    REFERENCES [dbo].[Acao]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AcaoPermissao'
CREATE INDEX [IX_FK_AcaoPermissao]
ON [dbo].[Permissao]
    ([AcaoId]);
GO

-- Creating foreign key on [FuncionalidadeId] in table 'Permissao'
ALTER TABLE [dbo].[Permissao]
ADD CONSTRAINT [FK_FuncionalidadePermissao]
    FOREIGN KEY ([FuncionalidadeId])
    REFERENCES [dbo].[Funcionalidade]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FuncionalidadePermissao'
CREATE INDEX [IX_FK_FuncionalidadePermissao]
ON [dbo].[Permissao]
    ([FuncionalidadeId]);
GO

-- Creating foreign key on [PerfilId] in table 'Permissao'
ALTER TABLE [dbo].[Permissao]
ADD CONSTRAINT [FK_PerfilPermissao]
    FOREIGN KEY ([PerfilId])
    REFERENCES [dbo].[Perfil]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerfilPermissao'
CREATE INDEX [IX_FK_PerfilPermissao]
ON [dbo].[Permissao]
    ([PerfilId]);
GO

-- Creating foreign key on [Acoes_Id] in table 'FuncionalidadeAcao'
ALTER TABLE [dbo].[FuncionalidadeAcao]
ADD CONSTRAINT [FK_FuncionalidadeAcao_Acao]
    FOREIGN KEY ([Acoes_Id])
    REFERENCES [dbo].[Acao]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [FuncionalidadeAcao_Acao_Id] in table 'FuncionalidadeAcao'
ALTER TABLE [dbo].[FuncionalidadeAcao]
ADD CONSTRAINT [FK_FuncionalidadeAcao_Funcionalidade]
    FOREIGN KEY ([FuncionalidadeAcao_Acao_Id])
    REFERENCES [dbo].[Funcionalidade]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FuncionalidadeAcao_Funcionalidade'
CREATE INDEX [IX_FK_FuncionalidadeAcao_Funcionalidade]
ON [dbo].[FuncionalidadeAcao]
    ([FuncionalidadeAcao_Acao_Id]);
GO

-- Creating foreign key on [ModuloId] in table 'Funcionalidade'
ALTER TABLE [dbo].[Funcionalidade]
ADD CONSTRAINT [FK_FuncionalidadeModulo]
    FOREIGN KEY ([ModuloId])
    REFERENCES [dbo].[Modulo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FuncionalidadeModulo'
CREATE INDEX [IX_FK_FuncionalidadeModulo]
ON [dbo].[Funcionalidade]
    ([ModuloId]);
GO

-- Creating foreign key on [PerfilId] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [FK_UsuarioPerfil]
    FOREIGN KEY ([PerfilId])
    REFERENCES [dbo].[Perfil]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioPerfil'
CREATE INDEX [IX_FK_UsuarioPerfil]
ON [dbo].[Usuario]
    ([PerfilId]);
GO

-- Creating foreign key on [ClienteId] in table 'Estacionamento'
ALTER TABLE [dbo].[Estacionamento]
ADD CONSTRAINT [FK_ClienteEstacionamento]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Cliente]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteEstacionamento'
CREATE INDEX [IX_FK_ClienteEstacionamento]
ON [dbo].[Estacionamento]
    ([ClienteId]);
GO

-- Creating foreign key on [EstacionamentoId] in table 'Cancela'
ALTER TABLE [dbo].[Cancela]
ADD CONSTRAINT [FK_CancelaEstacionamento]
    FOREIGN KEY ([EstacionamentoId])
    REFERENCES [dbo].[Estacionamento]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CancelaEstacionamento'
CREATE INDEX [IX_FK_CancelaEstacionamento]
ON [dbo].[Cancela]
    ([EstacionamentoId]);
GO

-- Creating foreign key on [CancelaId] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [FK_UsuarioCancela]
    FOREIGN KEY ([CancelaId])
    REFERENCES [dbo].[Cancela]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioCancela'
CREATE INDEX [IX_FK_UsuarioCancela]
ON [dbo].[Usuario]
    ([CancelaId]);
GO

-- Creating foreign key on [UsuarioId] in table 'Movimentacao'
ALTER TABLE [dbo].[Movimentacao]
ADD CONSTRAINT [FK_MovimentacaoUsuario]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[Usuario]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovimentacaoUsuario'
CREATE INDEX [IX_FK_MovimentacaoUsuario]
ON [dbo].[Movimentacao]
    ([UsuarioId]);
GO

-- Creating foreign key on [ClienteId] in table 'Competencia'
ALTER TABLE [dbo].[Competencia]
ADD CONSTRAINT [FK_CompetenciaCliente]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Cliente]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetenciaCliente'
CREATE INDEX [IX_FK_CompetenciaCliente]
ON [dbo].[Competencia]
    ([ClienteId]);
GO

-- Creating foreign key on [MovimentacaoId] in table 'Competencia'
ALTER TABLE [dbo].[Competencia]
ADD CONSTRAINT [FK_CompetenciaMovimentacao]
    FOREIGN KEY ([MovimentacaoId])
    REFERENCES [dbo].[Movimentacao]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetenciaMovimentacao'
CREATE INDEX [IX_FK_CompetenciaMovimentacao]
ON [dbo].[Competencia]
    ([MovimentacaoId]);
GO

-- Creating foreign key on [ClienteId] in table 'Movimentacao'
ALTER TABLE [dbo].[Movimentacao]
ADD CONSTRAINT [FK_MovimentacaoCliente]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Cliente]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovimentacaoCliente'
CREATE INDEX [IX_FK_MovimentacaoCliente]
ON [dbo].[Movimentacao]
    ([ClienteId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------