USE [Permisos]
GO

/****** Object:  Table [dbo].[TipoPermiso]    Script Date: 12/15/2019 1:53:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_NAME = 'Permiso'))
BEGIN
	CREATE TABLE [dbo].[Permiso](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[NombreEmpleado] [nvarchar](50) NOT NULL,
		[ApellidosEmpleado] [nvarchar](50) NOT NULL,
		[TipoPermisoId] [int] NULL,
		[FechaPermiso] [datetime] NULL,
	 CONSTRAINT [IX_Permiso] UNIQUE NONCLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Permiso_TipoPermiso] FOREIGN KEY([TipoPermisoId])
	REFERENCES [dbo].[TipoPermiso] ([Id])

	ALTER TABLE [dbo].[Permiso] CHECK CONSTRAINT [FK_Permiso_TipoPermiso]
END


