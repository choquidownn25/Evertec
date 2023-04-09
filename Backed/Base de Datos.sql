USE [master]
GO

/****** Object:  Database [Asesoftware]    Script Date: 18/06/2021 8:59:21 ******/
DROP DATABASE [Asesoftware]
GO

/****** Object:  Database [Asesoftware]    Script Date: 18/06/2021 8:59:22 ******/
CREATE DATABASE [Asesoftware]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Asesoftware', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Asesoftware.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Asesoftware_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Asesoftware_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Asesoftware].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Asesoftware] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Asesoftware] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Asesoftware] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Asesoftware] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Asesoftware] SET ARITHABORT OFF 
GO

ALTER DATABASE [Asesoftware] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Asesoftware] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Asesoftware] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Asesoftware] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Asesoftware] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Asesoftware] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Asesoftware] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Asesoftware] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Asesoftware] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Asesoftware] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Asesoftware] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Asesoftware] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Asesoftware] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Asesoftware] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Asesoftware] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Asesoftware] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Asesoftware] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Asesoftware] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Asesoftware] SET  MULTI_USER 
GO

ALTER DATABASE [Asesoftware] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Asesoftware] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Asesoftware] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Asesoftware] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [Asesoftware] SET  READ_WRITE 
GO


USE [Asesoftware]
GO

/****** Object:  Table [dbo].[Alumno]    Script Date: 18/06/2021 9:01:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Alumno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Direccion] [text] NULL,
	[Email] [text] NOT NULL,
	[Movil] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[IdNota] [int] NOT NULL,
	[IdGrado] [int] NOT NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_Grado] FOREIGN KEY([IdGrado])
REFERENCES [dbo].[Grado] ([Id])
GO

ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_Grado]
GO

ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_Nota] FOREIGN KEY([IdNota])
REFERENCES [dbo].[Nota] ([Id])
GO

ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_Nota]
GO


USE [Asesoftware]
GO

/****** Object:  Table [dbo].[Grado]    Script Date: 18/06/2021 9:02:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Grado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [text] NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Grado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


USE [Asesoftware]
GO

/****** Object:  Table [dbo].[Nota]    Script Date: 18/06/2021 9:02:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Nota](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [text] NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Nota] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


USE [Asesoftware]
GO

/****** Object:  Table [dbo].[IdentificaticionType]    Script Date: 18/06/2021 9:03:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[IdentificaticionType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [text] NULL,
	[Activo] [nchar](10) NULL,
 CONSTRAINT [PK_IdentificaticionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


USE [Asesoftware]
GO

/****** Object:  Table [dbo].[Costumer]    Script Date: 18/06/2021 9:03:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Costumer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [int] NULL,
	[PrimerNombre] [varchar](20) NULL,
	[SegundoNombre] [varchar](20) NULL,
	[Email] [varchar](20) NULL,
	[Direccion] [varchar](20) NULL,
	[Celular] [int] NULL,
	[IdType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Costumer]  WITH CHECK ADD  CONSTRAINT [FK_Costumer_IdentificaticionType] FOREIGN KEY([IdType])
REFERENCES [dbo].[IdentificaticionType] ([Id])
GO

ALTER TABLE [dbo].[Costumer] CHECK CONSTRAINT [FK_Costumer_IdentificaticionType]
GO


USE [Asesoftware]
GO

/****** Object:  Table [dbo].[Comercios]    Script Date: 18/06/2021 9:03:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Comercios](
	[id_comercio] [int] IDENTITY(1,1) NOT NULL,
	[nom_comercio] [nvarchar](50) NOT NULL,
	[afprp_maximo] [nvarchar](50) NULL,
 CONSTRAINT [PK_Comercios] PRIMARY KEY CLUSTERED 
(
	[id_comercio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [Asesoftware]
GO

/****** Object:  Table [dbo].[Services]    Script Date: 18/06/2021 9:04:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Services](
	[id_servicios] [int] IDENTITY(1,1) NOT NULL,
	[id_comercio] [int] NOT NULL,
	[nom_servicio] [nvarchar](50) NOT NULL,
	[hora_apertura] [time](7) NOT NULL,
	[hora_cierre] [time](7) NOT NULL,
	[duracion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[id_servicios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Comercios] FOREIGN KEY([id_comercio])
REFERENCES [dbo].[Comercios] ([id_comercio])
GO

ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Comercios]
GO


USE [Asesoftware]
GO

/****** Object:  Table [dbo].[Servicios]    Script Date: 18/06/2021 9:04:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Servicios](
	[id_servicios] [int] IDENTITY(1,1) NOT NULL,
	[id_comercio] [int] NOT NULL,
	[nom_servicio] [nvarchar](50) NOT NULL,
	[hora_apertura] [time](7) NOT NULL,
	[hora_cierre] [time](7) NOT NULL,
	[duracion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Servicios] PRIMARY KEY CLUSTERED 
(
	[id_servicios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD  CONSTRAINT [FK_Servicios_Comercios] FOREIGN KEY([id_comercio])
REFERENCES [dbo].[Comercios] ([id_comercio])
GO

ALTER TABLE [dbo].[Servicios] CHECK CONSTRAINT [FK_Servicios_Comercios]
GO


USE [Asesoftware]
GO

/****** Object:  Table [dbo].[Grafico]    Script Date: 18/06/2021 9:05:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Grafico](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Anno] [int] NOT NULL,
	[Valor] [int] NOT NULL,
 CONSTRAINT [PK_Grafico] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [Asesoftware]
GO

/****** Object:  Table [dbo].[Turno]    Script Date: 18/06/2021 9:06:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Turno](
	[id_turno] [int] IDENTITY(1,1) NOT NULL,
	[id_servicio] [int] NOT NULL,
	[fecha_turna] [datetime2](7) NOT NULL,
	[hora_inicio] [time](7) NOT NULL,
	[hora_fin] [time](7) NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_Turno] PRIMARY KEY CLUSTERED 
(
	[id_turno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Turno]  WITH CHECK ADD  CONSTRAINT [FK_Turno_Services] FOREIGN KEY([id_servicio])
REFERENCES [dbo].[Services] ([id_servicios])
GO

ALTER TABLE [dbo].[Turno] CHECK CONSTRAINT [FK_Turno_Services]
GO


