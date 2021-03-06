USE [LibreriaCeiba_B43478]
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 04/08/2017 12:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Autor](
	[id_autor] [int] IDENTITY(1,1) NOT NULL,
	[nombre_autor] [varchar](25) NULL,
	[primer_apellido] [varchar](25) NULL,
	[segundo_apellido] [varchar](25) NULL,
 CONSTRAINT [PK_Autor] PRIMARY KEY CLUSTERED 
(
	[id_autor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 04/08/2017 12:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Libro](
	[cod_libro] [int] IDENTITY(1,1) NOT NULL,
	[titulo_libro] [varchar](50) NULL,
	[ano_publicacion] [smallint] NULL,
	[isbn] [varchar](15) NULL,
	[id_publicador] [int] NULL,
	[precio] [float] NULL,
 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED 
(
	[cod_libro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Libro_Autor]    Script Date: 04/08/2017 12:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro_Autor](
	[cod_libro] [int] NOT NULL,
	[id_autor] [int] NOT NULL,
 CONSTRAINT [PK_Libro_Autor] PRIMARY KEY CLUSTERED 
(
	[cod_libro] ASC,
	[id_autor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Publicador]    Script Date: 04/08/2017 12:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Publicador](
	[id_publicador] [int] IDENTITY(1,1) NOT NULL,
	[nombre_publicador] [varchar](50) NULL,
	[url_sitio_web] [varchar](60) NULL,
 CONSTRAINT [PK_Publicador] PRIMARY KEY CLUSTERED 
(
	[id_publicador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD  CONSTRAINT [FK_Libro_Publicador] FOREIGN KEY([id_publicador])
REFERENCES [dbo].[Publicador] ([id_publicador])
GO
ALTER TABLE [dbo].[Libro] CHECK CONSTRAINT [FK_Libro_Publicador]
GO
ALTER TABLE [dbo].[Libro_Autor]  WITH CHECK ADD  CONSTRAINT [FK_Libro_Autor_Autor] FOREIGN KEY([id_autor])
REFERENCES [dbo].[Autor] ([id_autor])
GO
ALTER TABLE [dbo].[Libro_Autor] CHECK CONSTRAINT [FK_Libro_Autor_Autor]
GO
ALTER TABLE [dbo].[Libro_Autor]  WITH CHECK ADD  CONSTRAINT [FK_Libro_Autor_Libro] FOREIGN KEY([cod_libro])
REFERENCES [dbo].[Libro] ([cod_libro])
GO
ALTER TABLE [dbo].[Libro_Autor] CHECK CONSTRAINT [FK_Libro_Autor_Libro]
GO
/****** Object:  StoredProcedure [dbo].[InsertarLibro]    Script Date: 04/08/2017 12:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarLibro](
		@cod_libro int OUTPUT,
		@titulo_libro varchar(50),
		@ano_publicacion smallint,
		@isbn varchar(15),
		@id_publicador int,
		@precio float)
	AS
BEGIN
	INSERT INTO Libro(titulo_libro, ano_publicacion, isbn, id_publicador, precio)
    VALUES
           (RTRIM(@titulo_libro), RTRIM(@ano_publicacion), RTRIM(@isbn), RTRIM(@id_publicador), RTRIM(@precio))
    SELECT @cod_libro = @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[InsertarLibro_Autor]    Script Date: 04/08/2017 12:29:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarLibro_Autor](
		@cod_libro int,
		@id_autor int)
	AS
BEGIN
	INSERT INTO Libro_Autor(cod_libro, id_autor)
    VALUES
           (RTRIM(@cod_libro), RTRIM(@id_autor))
END

GO
