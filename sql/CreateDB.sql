USE [master];
GO

CREATE DATABASE [CSharpDapperAndFluentMapDb]
GO

USE [CSharpDapperAndFluentMapDb];
GO

CREATE TABLE Category
	(
		[Id] [uniqueidentifier] PRIMARY KEY NOT NULL,
		[Description] [varchar](100) NOT NULL
	);
GO

CREATE TABLE Person
	(
		[Id] [uniqueidentifier] PRIMARY KEY NOT NULL,
		[Name] [varchar](100) NOT NULL,
		[Age] [int] NOT NULL,
		[CategoryId] [uniqueidentifier] NOT NULL,
			CONSTRAINT FK_Person_CategoryId_Category_Id
				FOREIGN KEY (CategoryId)
				REFERENCES Category(Id)
	);
GO

CREATE TABLE [Priority]
	(
		[Id] [uniqueidentifier] PRIMARY KEY NOT NULL,
		[Description] [varchar](30) NOT NULL		
	);
GO

CREATE TABLE Ticket
	(
		[Id] [uniqueidentifier] PRIMARY KEY NOT NULL,
		[Description] [varchar](300) NOT NULL,
		[PersonId] [uniqueidentifier] NOT NULL
			CONSTRAINT FK_Ticket_PersonId_Person_Id
				FOREIGN KEY (PersonId)
				REFERENCES Person(Id),
		[PriorityId] [uniqueidentifier] NOT NULL
			CONSTRAINT FK_Ticket_PriorityId_Priority_Id
				FOREIGN KEY (PriorityId)
				REFERENCES Priority(Id)
	);
GO

INSERT INTO Category(Id, Description) 
	VALUES ('7ec07b3c-7bcf-42cb-9495-7cbe662a2ddb', 'Comercial'),
           ('da060ea4-606d-431c-88ef-f0e1f69d7387', 'Internal');
GO

INSERT INTO Person(Id, Name, Age, CategoryId) 
	VALUES ('1aab120b-ed08-49e0-939e-16ec24bf2130', 'Tiago Pariz', 35, '7ec07b3c-7bcf-42cb-9495-7cbe662a2ddb'), 
		   ('24dfeba1-27b0-4d64-b30f-044d5eb44786', 'Rodrigo Gonçalves', 31, 'da060ea4-606d-431c-88ef-f0e1f69d7387'), 
		   ('3c04c499-996c-4dd0-b24e-3b8510fdbccf', 'Daniel Silva', 25, '7ec07b3c-7bcf-42cb-9495-7cbe662a2ddb'), 
		   ('4239a808-87cc-45a7-8987-0f87249bcb4c', 'Fabiano Fonseca', 42, '7ec07b3c-7bcf-42cb-9495-7cbe662a2ddb');
GO

INSERT INTO Priority(Id, Description) 
	VALUES ('19b9cd1a-e444-47ed-a646-581ec731f195', 'Low'),
           ('27111b9b-8653-4f4c-af65-5e5fe8ffe565', 'Default'),
           ('3b5c5ea3-cffb-4d36-a80d-427d7d24195c', 'Hight');
GO

INSERT INTO Ticket(Id, [Description], PersonId, PriorityId) 
	VALUES ('b272486f-8173-439a-9c50-1ca728f76388', 'Create Email', '1aab120b-ed08-49e0-939e-16ec24bf2130', '27111b9b-8653-4f4c-af65-5e5fe8ffe565'), 
		   ('c8d61a46-01f5-4e1a-bfbd-3db9a10e96fb', 'Format Windows', '1aab120b-ed08-49e0-939e-16ec24bf2130', '19b9cd1a-e444-47ed-a646-581ec731f195'), 
		   ('79467146-52a1-4fc1-9804-f5d3e9d216c5', 'Install VS', '24dfeba1-27b0-4d64-b30f-044d5eb44786', '3b5c5ea3-cffb-4d36-a80d-427d7d24195c'),
		   ('a09598e4-2fd5-48d4-9a5f-baf84f776744', 'Blue screen issue', '4239a808-87cc-45a7-8987-0f87249bcb4c', '3b5c5ea3-cffb-4d36-a80d-427d7d24195c'),
		   ('5c4d1e1c-90a9-48fe-9131-6e29c15feca7', 'Install notepad++', '3c04c499-996c-4dd0-b24e-3b8510fdbccf', '19b9cd1a-e444-47ed-a646-581ec731f195'),
		   ('cf9a1a1f-fb51-487e-aa86-290e38e87a52', 'Create AD user', '24dfeba1-27b0-4d64-b30f-044d5eb44786', '27111b9b-8653-4f4c-af65-5e5fe8ffe565'), 
		   ('670d471a-e640-4adf-b65e-3a69adfd80d4', 'Install office 2019', '1aab120b-ed08-49e0-939e-16ec24bf2130', '3b5c5ea3-cffb-4d36-a80d-427d7d24195c'), 
		   ('785b637a-c080-44c9-9d25-e0cfd9211e01', 'Verify wi-fi', '1aab120b-ed08-49e0-939e-16ec24bf2130', '19b9cd1a-e444-47ed-a646-581ec731f195'),
		   ('0fc7871f-9e9d-4096-9649-50581c4f1afa', 'Blue screen issue', '3c04c499-996c-4dd0-b24e-3b8510fdbccf', '3b5c5ea3-cffb-4d36-a80d-427d7d24195c'),
		   ('22c9b520-74de-4abc-8ba4-890a1bd0c204', 'Install SQL Server', '3c04c499-996c-4dd0-b24e-3b8510fdbccf', '27111b9b-8653-4f4c-af65-5e5fe8ffe565');
GO