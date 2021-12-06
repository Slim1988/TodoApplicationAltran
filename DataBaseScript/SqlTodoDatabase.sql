/*******************************************************************************
   Drop database if it exists
********************************************************************************/
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'TodosDB')
BEGIN
	ALTER DATABASE [TodosDB] SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE [TodosDB] SET ONLINE;
	DROP DATABASE [TodosDB];
END

GO

/*******************************************************************************
   Create database
********************************************************************************/
CREATE DATABASE [TodosDB];
GO

USE [TodosDB];
GO

/*******************************************************************************
   Create Tables
********************************************************************************/

CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Todo](
	[TodoId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[State] [bit] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Todo] PRIMARY KEY CLUSTERED 
(
	[TodoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Todo]  WITH CHECK ADD  CONSTRAINT [FK_Todo_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Todo] CHECK CONSTRAINT [FK_Todo_User]
GO


/*******************************************************************************
   Insert Datas
********************************************************************************/

USE [TodosDB]
GO

INSERT INTO [dbo].[User]
           ([UserName]
           ,[Password])
     VALUES      
		   ('Admin'
           ,'admin'),
		   ('Slim'
           ,'1988')

GO

INSERT INTO [dbo].[Todo]
           ([UserId]
           ,[Title]
           ,[State]
           ,[Description])
     VALUES
           (1
           ,'Acheter les billets'
           ,0
           ,'Billets d''avion pour le voyage a Barcelone'),
		    (1
           ,'Faire les course'
           ,0
           ,'Faire les courses en lignes depuis le site Leclerc Drive'),
		    (1
           ,'Entretien '
           ,0
           ,'Entretien d''ambauche '),
		   (1
           ,'Lire  '
           ,0
           ,'Lire un livre '),
		   
		   (2
           ,'Visite appartement'
           ,0
           ,'Visite appartement en visio'),
		    (2
           ,'Faire les course'
           ,0
           ,'Faire les courses en lignes depuis le site Leclerc Drive'),
		    (2
           ,'Entretien '
           ,0
           ,'Entretien d''ambauche '),
		   (2
           ,'Lire  '
           ,0
           ,'Lire un livre ')

GO


