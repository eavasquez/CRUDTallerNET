CREATE DATABASE CRUD_1
USE CRUD_1
CREATE TABLE [dbo].[Articulos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Tipo] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
	[PrecioVenta] [varchar](50) NULL,
	[Activo] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 24-11-2018 12:05:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RUT] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Cargo] [varchar](50) NULL,
	[Activo] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documentos]    Script Date: 24-11-2018 12:05:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [varchar](50) NULL,
	[Tipo] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
	[Monto] [varchar](50) NULL,
	[Pagado] [varchar](50) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([Id], [RUT], [Nombre], [Apellido], [Cargo], [Activo]) VALUES (5, N'127389719', N'Erwin', N'Vasquez', N'Soporte IT', N'No')

SET IDENTITY_INSERT [dbo].[Cliente] OFF
SET IDENTITY_INSERT [dbo].[Documentos] ON 

INSERT [dbo].[Documentos] ([Id], [Numero], [Tipo], [Descripcion], [Monto], [Pagado]) VALUES (3, N'1123', N'Boleta', N'LLamativo Ltda', N'Natural', N'Si')
INSERT [dbo].[Documentos] ([Id], [Numero], [Tipo], [Descripcion], [Monto], [Pagado]) VALUES (4, N'1123', N'Boleta', N'LLamativo Ltda', N'Natural', N'Si')
INSERT [dbo].[Documentos] ([Id], [Numero], [Tipo], [Descripcion], [Monto], [Pagado]) VALUES (5, N'1123', N'Boleta', N'LLamativo Ltda', N'Natural', N'Si')
SET IDENTITY_INSERT [dbo].[Documentos] OFF

SELECT * FROM dbo.Cliente