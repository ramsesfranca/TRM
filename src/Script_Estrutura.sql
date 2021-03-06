USE [SAP]
GO
/****** Object:  Table [dbo].[Acao]    Script Date: 14/12/2018 18:16:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Texto] [nvarchar](50) NULL,
 CONSTRAINT [PK_Acao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cancela]    Script Date: 14/12/2018 18:16:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cancela](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[EstacionamentoId] [int] NOT NULL,
 CONSTRAINT [PK_Cancela] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 14/12/2018 18:16:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](80) NOT NULL,
	[CNPJ] [nvarchar](18) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Competencia]    Script Date: 14/12/2018 18:16:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Competencia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Valor] [decimal](10, 2) NOT NULL,
	[Pago] [bit] NOT NULL,
	[Mes] [int] NOT NULL,
	[Ano] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[MovimentacaoId] [int] NOT NULL,
 CONSTRAINT [PK_Competencia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estacionamento]    Script Date: 14/12/2018 18:16:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estacionamento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](80) NOT NULL,
	[Endereco] [nvarchar](80) NOT NULL,
	[QtdVagas] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
 CONSTRAINT [PK_Estacionamento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funcionalidade]    Script Date: 14/12/2018 18:16:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionalidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Texto] [nvarchar](50) NOT NULL,
	[Controlador] [nvarchar](50) NOT NULL,
	[Acao] [nvarchar](50) NULL,
	[Ordem] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[ModuloId] [int] NOT NULL,
 CONSTRAINT [PK_Funcionalidade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FuncionalidadeAcao]    Script Date: 14/12/2018 18:16:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FuncionalidadeAcao](
	[Acoes_Id] [int] NOT NULL,
	[FuncionalidadeAcao_Acao_Id] [int] NOT NULL,
 CONSTRAINT [PK_FuncionalidadeAcao] PRIMARY KEY CLUSTERED 
(
	[Acoes_Id] ASC,
	[FuncionalidadeAcao_Acao_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modulo]    Script Date: 14/12/2018 18:16:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modulo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Area] [nvarchar](50) NOT NULL,
	[Ordem] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Modulo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimentacao]    Script Date: 14/12/2018 18:16:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimentacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlacaCarro] [nvarchar](max) NOT NULL,
	[Marca] [nvarchar](80) NOT NULL,
	[Modelo] [nvarchar](80) NOT NULL,
	[Ticket] [nvarchar](10) NOT NULL,
	[DataHoraEntrada] [datetime] NOT NULL,
	[DataHoraSaida] [datetime] NULL,
	[TipoMovimentacao] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
 CONSTRAINT [PK_Movimentacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 14/12/2018 18:16:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissao]    Script Date: 14/12/2018 18:16:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PerfilId] [int] NOT NULL,
	[FuncionalidadeId] [int] NOT NULL,
	[AcaoId] [int] NOT NULL,
 CONSTRAINT [PK_Permissao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 14/12/2018 18:16:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](80) NOT NULL,
	[CPF] [nvarchar](18) NOT NULL,
	[Login] [nvarchar](80) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Senha] [nvarchar](50) NOT NULL,
	[DataHoraLogin] [datetime] NULL,
	[Status] [int] NOT NULL,
	[PerfilId] [int] NOT NULL,
	[CancelaId] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cancela]  WITH CHECK ADD  CONSTRAINT [FK_CancelaEstacionamento] FOREIGN KEY([EstacionamentoId])
REFERENCES [dbo].[Estacionamento] ([Id])
GO
ALTER TABLE [dbo].[Cancela] CHECK CONSTRAINT [FK_CancelaEstacionamento]
GO
ALTER TABLE [dbo].[Competencia]  WITH CHECK ADD  CONSTRAINT [FK_CompetenciaCliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Competencia] CHECK CONSTRAINT [FK_CompetenciaCliente]
GO
ALTER TABLE [dbo].[Competencia]  WITH CHECK ADD  CONSTRAINT [FK_CompetenciaMovimentacao] FOREIGN KEY([MovimentacaoId])
REFERENCES [dbo].[Movimentacao] ([Id])
GO
ALTER TABLE [dbo].[Competencia] CHECK CONSTRAINT [FK_CompetenciaMovimentacao]
GO
ALTER TABLE [dbo].[Estacionamento]  WITH CHECK ADD  CONSTRAINT [FK_ClienteEstacionamento] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Estacionamento] CHECK CONSTRAINT [FK_ClienteEstacionamento]
GO
ALTER TABLE [dbo].[Funcionalidade]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadeModulo] FOREIGN KEY([ModuloId])
REFERENCES [dbo].[Modulo] ([Id])
GO
ALTER TABLE [dbo].[Funcionalidade] CHECK CONSTRAINT [FK_FuncionalidadeModulo]
GO
ALTER TABLE [dbo].[FuncionalidadeAcao]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadeAcao_Acao] FOREIGN KEY([Acoes_Id])
REFERENCES [dbo].[Acao] ([Id])
GO
ALTER TABLE [dbo].[FuncionalidadeAcao] CHECK CONSTRAINT [FK_FuncionalidadeAcao_Acao]
GO
ALTER TABLE [dbo].[FuncionalidadeAcao]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadeAcao_Funcionalidade] FOREIGN KEY([FuncionalidadeAcao_Acao_Id])
REFERENCES [dbo].[Funcionalidade] ([Id])
GO
ALTER TABLE [dbo].[FuncionalidadeAcao] CHECK CONSTRAINT [FK_FuncionalidadeAcao_Funcionalidade]
GO
ALTER TABLE [dbo].[Movimentacao]  WITH CHECK ADD  CONSTRAINT [FK_MovimentacaoCliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Movimentacao] CHECK CONSTRAINT [FK_MovimentacaoCliente]
GO
ALTER TABLE [dbo].[Movimentacao]  WITH CHECK ADD  CONSTRAINT [FK_MovimentacaoUsuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Movimentacao] CHECK CONSTRAINT [FK_MovimentacaoUsuario]
GO
ALTER TABLE [dbo].[Permissao]  WITH CHECK ADD  CONSTRAINT [FK_AcaoPermissao] FOREIGN KEY([AcaoId])
REFERENCES [dbo].[Acao] ([Id])
GO
ALTER TABLE [dbo].[Permissao] CHECK CONSTRAINT [FK_AcaoPermissao]
GO
ALTER TABLE [dbo].[Permissao]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadePermissao] FOREIGN KEY([FuncionalidadeId])
REFERENCES [dbo].[Funcionalidade] ([Id])
GO
ALTER TABLE [dbo].[Permissao] CHECK CONSTRAINT [FK_FuncionalidadePermissao]
GO
ALTER TABLE [dbo].[Permissao]  WITH CHECK ADD  CONSTRAINT [FK_PerfilPermissao] FOREIGN KEY([PerfilId])
REFERENCES [dbo].[Perfil] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Permissao] CHECK CONSTRAINT [FK_PerfilPermissao]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioCancela] FOREIGN KEY([CancelaId])
REFERENCES [dbo].[Cancela] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_UsuarioCancela]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPerfil] FOREIGN KEY([PerfilId])
REFERENCES [dbo].[Perfil] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_UsuarioPerfil]
GO
