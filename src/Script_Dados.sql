USE [SAP]
GO
SET IDENTITY_INSERT [dbo].[Acao] ON 
GO
INSERT [dbo].[Acao] ([Id], [Nome], [Texto]) VALUES (1, N'Inserir', N'Inserir')
GO
INSERT [dbo].[Acao] ([Id], [Nome], [Texto]) VALUES (2, N'Alterar', N'Alterar')
GO
INSERT [dbo].[Acao] ([Id], [Nome], [Texto]) VALUES (3, N'Deletar', N'Deletar')
GO
INSERT [dbo].[Acao] ([Id], [Nome], [Texto]) VALUES (4, N'Listar', N'Listar')
GO
INSERT [dbo].[Acao] ([Id], [Nome], [Texto]) VALUES (5, N'Visualizar', N'Visualizar')
GO
SET IDENTITY_INSERT [dbo].[Acao] OFF
GO
SET IDENTITY_INSERT [dbo].[Modulo] ON 
GO
INSERT [dbo].[Modulo] ([Id], [Nome], [Area], [Ordem], [Status]) VALUES (1, N'Sistema', N'Sistema', 2, 1)
GO
INSERT [dbo].[Modulo] ([Id], [Nome], [Area], [Ordem], [Status]) VALUES (2, N'Gestão', N'Gestao', 1, 1)
GO
INSERT [dbo].[Modulo] ([Id], [Nome], [Area], [Ordem], [Status]) VALUES (3, N'Cadastro', N'Cadastro', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Modulo] OFF
GO
SET IDENTITY_INSERT [dbo].[Funcionalidade] ON 
GO
INSERT [dbo].[Funcionalidade] ([Id], [Nome], [Texto], [Controlador], [Acao], [Ordem], [Status], [ModuloId]) VALUES (1, N'Perfil', N'Perfil', N'Perfil', N'Index', 1, 1, 1)
GO
INSERT [dbo].[Funcionalidade] ([Id], [Nome], [Texto], [Controlador], [Acao], [Ordem], [Status], [ModuloId]) VALUES (2, N'Usuário', N'Usuário', N'Usuario', N'Index', 2, 1, 1)
GO
INSERT [dbo].[Funcionalidade] ([Id], [Nome], [Texto], [Controlador], [Acao], [Ordem], [Status], [ModuloId]) VALUES (3, N'Cliente', N'Cliente', N'Cliente', N'Index', 1, 1, 3)
GO
INSERT [dbo].[Funcionalidade] ([Id], [Nome], [Texto], [Controlador], [Acao], [Ordem], [Status], [ModuloId]) VALUES (5, N'Estacionamento', N'Estacionamento', N'Estacionamento', N'Index', 2, 1, 3)
GO
INSERT [dbo].[Funcionalidade] ([Id], [Nome], [Texto], [Controlador], [Acao], [Ordem], [Status], [ModuloId]) VALUES (6, N'Cancela', N'Cancela', N'Cancela', N'Index', 3, 1, 3)
GO
INSERT [dbo].[Funcionalidade] ([Id], [Nome], [Texto], [Controlador], [Acao], [Ordem], [Status], [ModuloId]) VALUES (7, N'Competencia', N'Competência', N'Competencia', N'Index', 1, 1, 2)
GO
SET IDENTITY_INSERT [dbo].[Funcionalidade] OFF
GO
SET IDENTITY_INSERT [dbo].[Perfil] ON 
GO
INSERT [dbo].[Perfil] ([Id], [Nome]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[Perfil] ([Id], [Nome]) VALUES (2, N'Operador')
GO
SET IDENTITY_INSERT [dbo].[Perfil] OFF
GO
SET IDENTITY_INSERT [dbo].[Permissao] ON 
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (214, 1, 1, 1)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (215, 1, 1, 2)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (216, 1, 1, 3)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (217, 1, 1, 4)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (218, 1, 2, 1)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (219, 1, 2, 2)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (220, 1, 2, 3)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (221, 1, 2, 5)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (222, 1, 2, 4)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (223, 1, 3, 1)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (224, 1, 3, 2)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (225, 1, 3, 3)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (226, 1, 3, 4)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (227, 1, 3, 5)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (228, 1, 5, 1)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (229, 1, 5, 2)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (230, 1, 5, 3)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (231, 1, 5, 4)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (232, 1, 5, 5)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (233, 1, 6, 1)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (234, 1, 6, 2)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (235, 1, 6, 3)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (236, 1, 6, 4)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (237, 1, 6, 5)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (238, 1, 7, 1)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (239, 1, 7, 2)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (240, 1, 7, 3)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (241, 1, 7, 4)
GO
INSERT [dbo].[Permissao] ([Id], [PerfilId], [FuncionalidadeId], [AcaoId]) VALUES (242, 1, 7, 5)
GO
SET IDENTITY_INSERT [dbo].[Permissao] OFF
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (1, 1)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (2, 1)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (3, 1)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (4, 1)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (1, 2)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (2, 2)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (3, 2)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (4, 2)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (5, 2)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (1, 3)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (2, 3)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (3, 3)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (4, 3)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (5, 3)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (1, 5)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (2, 5)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (3, 5)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (4, 5)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (5, 5)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (1, 6)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (2, 6)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (3, 6)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (4, 6)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (5, 6)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (1, 7)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (2, 7)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (3, 7)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (4, 7)
GO
INSERT [dbo].[FuncionalidadeAcao] ([Acoes_Id], [FuncionalidadeAcao_Acao_Id]) VALUES (5, 7)
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([Id], [Nome], [CNPJ], [Email]) VALUES (1, N'Estapar Estacionamento', N'82.239.422/0001-89', N'estapar@gmail.com')
GO
INSERT [dbo].[Cliente] ([Id], [Nome], [CNPJ], [Email]) VALUES (2, N'Teste 1', N'63.156.315/0001-42', N'teste@teste.com')
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Estacionamento] ON 
GO
INSERT [dbo].[Estacionamento] ([Id], [Nome], [Endereco], [QtdVagas], [ClienteId]) VALUES (1, N'Imbiribeira', N'Av. Mal. Mascarenhas de Morais, 6211 - Imbiribeira, Recife - PE', 1000, 1)
GO
INSERT [dbo].[Estacionamento] ([Id], [Nome], [Endereco], [QtdVagas], [ClienteId]) VALUES (2, N'Domingos Ferreira', N'Av. Eng. Domingos Ferreira - Pina', 500, 1)
GO
SET IDENTITY_INSERT [dbo].[Estacionamento] OFF
GO
SET IDENTITY_INSERT [dbo].[Cancela] ON 
GO
INSERT [dbo].[Cancela] ([Id], [Nome], [EstacionamentoId]) VALUES (1, N'Norte', 1)
GO
INSERT [dbo].[Cancela] ([Id], [Nome], [EstacionamentoId]) VALUES (2, N'Sul', 1)
GO
INSERT [dbo].[Cancela] ([Id], [Nome], [EstacionamentoId]) VALUES (3, N'Principal ', 2)
GO
SET IDENTITY_INSERT [dbo].[Cancela] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [CPF], [Login], [Email], [Senha], [DataHoraLogin], [Status], [PerfilId], [CancelaId]) VALUES (1, N'Administrador', N'000.000.000-00', N'admin', N'admin@teste.com', N'73l8gRjwLftklgfdXT+MdiMEjJwGPVMsyVxe16iYpk8=', CAST(N'2018-12-14T17:45:33.030' AS DateTime), 1, 1, NULL)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [CPF], [Login], [Email], [Senha], [DataHoraLogin], [Status], [PerfilId], [CancelaId]) VALUES (2, N'Ramsés França dos Prazeres', N'283.112.726-20', N'ramses.prazeres', N'ramsesfranca87@gmail.com', N'73l8gRjwLftklgfdXT+MdiMEjJwGPVMsyVxe16iYpk8=', NULL, 1, 1, NULL)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [CPF], [Login], [Email], [Senha], [DataHoraLogin], [Status], [PerfilId], [CancelaId]) VALUES (3, N'Sheylla Cristiane Oliveira dos Santos', N'753.331.185-07', N'sheylla.santos', N'5b062f0fa2@mailox.fun', N'ipvPHlHoEtCvhGWo28yfdBBkvwrzs9COawJGQ3wZ9/s=', NULL, 1, 1, NULL)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [CPF], [Login], [Email], [Senha], [DataHoraLogin], [Status], [PerfilId], [CancelaId]) VALUES (4, N'Vinicius Santos Moraes Barbosa', N'314.058.412-14', N'vinicius.santos', N'teste@teste.com', N'73l8gRjwLftklgfdXT+MdiMEjJwGPVMsyVxe16iYpk8=', CAST(N'2018-12-14T17:44:02.433' AS DateTime), 1, 2, 1)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [CPF], [Login], [Email], [Senha], [DataHoraLogin], [Status], [PerfilId], [CancelaId]) VALUES (5, N'Yuri França dos Prazeres', N'777.785.883-15', N'yuri.prazeres', N'teste@teste.com', N'73l8gRjwLftklgfdXT+MdiMEjJwGPVMsyVxe16iYpk8=', NULL, 1, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimentacao] ON 
GO
INSERT [dbo].[Movimentacao] ([Id], [PlacaCarro], [Marca], [Modelo], [Ticket], [DataHoraEntrada], [DataHoraSaida], [TipoMovimentacao], [UsuarioId], [ClienteId]) VALUES (2, N'AAA-1111', N'Teste 1', N'Teste 1', N'7048059583', CAST(N'2018-12-13T18:07:29.847' AS DateTime), CAST(N'2018-12-14T09:36:40.617' AS DateTime), 2, 1, 1)
GO
INSERT [dbo].[Movimentacao] ([Id], [PlacaCarro], [Marca], [Modelo], [Ticket], [DataHoraEntrada], [DataHoraSaida], [TipoMovimentacao], [UsuarioId], [ClienteId]) VALUES (3, N'AAA-2222', N'Teste 2', N'Teste 2', N'8379247776', CAST(N'2018-12-14T09:37:28.070' AS DateTime), CAST(N'2018-12-14T09:41:01.010' AS DateTime), 2, 1, 1)
GO
INSERT [dbo].[Movimentacao] ([Id], [PlacaCarro], [Marca], [Modelo], [Ticket], [DataHoraEntrada], [DataHoraSaida], [TipoMovimentacao], [UsuarioId], [ClienteId]) VALUES (4, N'BBB-1111', N'Teste 3', N'Teste 3', N'6011794751', CAST(N'2018-12-14T10:50:58.800' AS DateTime), CAST(N'2018-12-14T10:54:22.913' AS DateTime), 2, 1, 1)
GO
INSERT [dbo].[Movimentacao] ([Id], [PlacaCarro], [Marca], [Modelo], [Ticket], [DataHoraEntrada], [DataHoraSaida], [TipoMovimentacao], [UsuarioId], [ClienteId]) VALUES (1002, N'CCC-1111', N'Teste 4', N'Teste 4', N'8246503709', CAST(N'2018-12-14T17:44:23.823' AS DateTime), CAST(N'2018-12-14T17:45:11.510' AS DateTime), 2, 4, 1)
GO
SET IDENTITY_INSERT [dbo].[Movimentacao] OFF
GO
SET IDENTITY_INSERT [dbo].[Competencia] ON 
GO
INSERT [dbo].[Competencia] ([Id], [Valor], [Pago], [Mes], [Ano], [ClienteId], [MovimentacaoId]) VALUES (3, CAST(6.03 AS Decimal(10, 2)), 0, 12, 2018, 1, 2)
GO
INSERT [dbo].[Competencia] ([Id], [Valor], [Pago], [Mes], [Ano], [ClienteId], [MovimentacaoId]) VALUES (4, CAST(0.02 AS Decimal(10, 2)), 0, 12, 2018, 1, 3)
GO
INSERT [dbo].[Competencia] ([Id], [Valor], [Pago], [Mes], [Ano], [ClienteId], [MovimentacaoId]) VALUES (8, CAST(0.01 AS Decimal(10, 2)), 0, 12, 2018, 1, 4)
GO
INSERT [dbo].[Competencia] ([Id], [Valor], [Pago], [Mes], [Ano], [ClienteId], [MovimentacaoId]) VALUES (1002, CAST(0.00 AS Decimal(10, 2)), 0, 12, 2018, 1, 1002)
GO
SET IDENTITY_INSERT [dbo].[Competencia] OFF
GO
