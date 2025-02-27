USE [master]
GO
/****** Object:  Database [full_stack]    Script Date: 31/1/2025 20:44:00 ******/
CREATE DATABASE [full_stack]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'full_stack', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\full_stack.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'full_stack_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\full_stack_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [full_stack] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [full_stack].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [full_stack] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [full_stack] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [full_stack] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [full_stack] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [full_stack] SET ARITHABORT OFF 
GO
ALTER DATABASE [full_stack] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [full_stack] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [full_stack] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [full_stack] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [full_stack] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [full_stack] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [full_stack] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [full_stack] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [full_stack] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [full_stack] SET  DISABLE_BROKER 
GO
ALTER DATABASE [full_stack] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [full_stack] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [full_stack] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [full_stack] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [full_stack] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [full_stack] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [full_stack] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [full_stack] SET RECOVERY FULL 
GO
ALTER DATABASE [full_stack] SET  MULTI_USER 
GO
ALTER DATABASE [full_stack] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [full_stack] SET DB_CHAINING OFF 
GO
ALTER DATABASE [full_stack] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [full_stack] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [full_stack] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [full_stack] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'full_stack', N'ON'
GO
ALTER DATABASE [full_stack] SET QUERY_STORE = ON
GO
ALTER DATABASE [full_stack] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [full_stack]
GO
/****** Object:  Table [dbo].[Campo]    Script Date: 31/1/2025 20:44:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FormularioId] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Formulario]    Script Date: 31/1/2025 20:44:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formulario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registro]    Script Date: 31/1/2025 20:44:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FormularioId] [int] NULL,
	[FechaCreacion] [datetime] NULL,
 CONSTRAINT [PK_Registro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respuesta]    Script Date: 31/1/2025 20:44:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuesta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CampoId] [int] NOT NULL,
	[Valor] [varchar](255) NOT NULL,
	[RegistroId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Campo] ON 

INSERT [dbo].[Campo] ([Id], [FormularioId], [Nombre], [tipo]) VALUES (3, 1, N'Alias', N'text')
INSERT [dbo].[Campo] ([Id], [FormularioId], [Nombre], [tipo]) VALUES (4, 1, N'estatura', N'number')
INSERT [dbo].[Campo] ([Id], [FormularioId], [Nombre], [tipo]) VALUES (5, 1, N'correo', N'email')
INSERT [dbo].[Campo] ([Id], [FormularioId], [Nombre], [tipo]) VALUES (6, 2, N'nombre', N'text')
INSERT [dbo].[Campo] ([Id], [FormularioId], [Nombre], [tipo]) VALUES (7, 2, N'especie', N'text')
INSERT [dbo].[Campo] ([Id], [FormularioId], [Nombre], [tipo]) VALUES (8, 2, N'raza', N'text')
INSERT [dbo].[Campo] ([Id], [FormularioId], [Nombre], [tipo]) VALUES (9, 2, N'color', N'text')
INSERT [dbo].[Campo] ([Id], [FormularioId], [Nombre], [tipo]) VALUES (10, 2, N'fechaNacimiento', N'date')
INSERT [dbo].[Campo] ([Id], [FormularioId], [Nombre], [tipo]) VALUES (11, 1, N'nombres', N'text')
INSERT [dbo].[Campo] ([Id], [FormularioId], [Nombre], [tipo]) VALUES (12, 1, N'cedula', N'text')
INSERT [dbo].[Campo] ([Id], [FormularioId], [Nombre], [tipo]) VALUES (13, 1, N'estado', N'text')
SET IDENTITY_INSERT [dbo].[Campo] OFF
GO
SET IDENTITY_INSERT [dbo].[Formulario] ON 

INSERT [dbo].[Formulario] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Personas', N'Formulario para registro de datos personales')
INSERT [dbo].[Formulario] ([Id], [Nombre], [Descripcion]) VALUES (2, N'Mascotas', N'Formulario para registro de mascotas')
INSERT [dbo].[Formulario] ([Id], [Nombre], [Descripcion]) VALUES (3, N'Personas', N'Formulario para registro de personas')
INSERT [dbo].[Formulario] ([Id], [Nombre], [Descripcion]) VALUES (4, N'CARRO', N'TRANSPORTE')
INSERT [dbo].[Formulario] ([Id], [Nombre], [Descripcion]) VALUES (5, N'Personas', N'Formulario para registro de personas')
SET IDENTITY_INSERT [dbo].[Formulario] OFF
GO
ALTER TABLE [dbo].[Campo]  WITH CHECK ADD FOREIGN KEY([FormularioId])
REFERENCES [dbo].[Formulario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Respuesta]  WITH CHECK ADD  CONSTRAINT [FK_Respuesta_Campo] FOREIGN KEY([CampoId])
REFERENCES [dbo].[Campo] ([Id])
GO
ALTER TABLE [dbo].[Respuesta] CHECK CONSTRAINT [FK_Respuesta_Campo]
GO
ALTER TABLE [dbo].[Respuesta]  WITH CHECK ADD  CONSTRAINT [FK_Respuesta_Registro] FOREIGN KEY([RegistroId])
REFERENCES [dbo].[Registro] ([Id])
GO
ALTER TABLE [dbo].[Respuesta] CHECK CONSTRAINT [FK_Respuesta_Registro]
GO
USE [master]
GO
ALTER DATABASE [full_stack] SET  READ_WRITE 
GO
