USE [Permisos]
GO

/****** Object:  Table [dbo].[TipoPermiso]    Script Date: 12/15/2019 1:53:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_NAME = 'TipoPermiso'))
BEGIN
	CREATE TABLE [dbo].[TipoPermiso](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Descripcion] [nvarchar](50) NOT NULL,
	 CONSTRAINT [IX_TipoPermiso] UNIQUE NONCLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]END
ELSE
BEGIN
	print 'Tabla TipoPermiso ya existe'
END
GO
IF NOT (EXISTS (SELECT * FROM TipoPermiso))
BEGIN
	INSERT INTO [dbo].[TipoPermiso] (Descripcion) VALUES ('Enfermedad')
	INSERT INTO [dbo].[TipoPermiso] (Descripcion) VALUES ('Diligecias')
	INSERT INTO [dbo].[TipoPermiso] (Descripcion) VALUES ('Vacaciones')
	INSERT INTO [dbo].[TipoPermiso] (Descripcion) VALUES ('Días por Estudio')
	INSERT INTO [dbo].[TipoPermiso] (Descripcion) VALUES ('Licencia por Matrimonio')
END

