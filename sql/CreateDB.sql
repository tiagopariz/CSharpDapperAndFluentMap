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

CREATE TABLE Project
	(
		[Id] [uniqueidentifier] PRIMARY KEY NOT NULL,
		[Name] [varchar](100) NOT NULL		
	);
GO

CREATE TABLE PersonProject
	(
		[Id] [uniqueidentifier] PRIMARY KEY NOT NULL,
		[ProjectId] [uniqueidentifier] NOT NULL
			CONSTRAINT FK_PersonProject_ProjectId_Project_Id
				FOREIGN KEY (ProjectId)
				REFERENCES Project(Id),
		[PersonId] [uniqueidentifier] NOT NULL
			CONSTRAINT FK_PersonProject_PersonId_Person_Id
				FOREIGN KEY (PersonId)
				REFERENCES Person(Id)
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
				REFERENCES Priority(Id),
		[ProjectId] [uniqueidentifier] NULL
			CONSTRAINT FK_Ticket_ProjectId_Project_Id
				FOREIGN KEY (ProjectId)
				REFERENCES Project(Id)
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
		   ('4239a808-87cc-45a7-8987-0f87249bcb4c', 'Fabiano Fonseca', 42, '7ec07b3c-7bcf-42cb-9495-7cbe662a2ddb'),
		   ('52e1ed3e-b4c6-49d6-9314-88557beb8f5c', 'José João', 42, 'da060ea4-606d-431c-88ef-f0e1f69d7387');
GO

INSERT INTO Project(Id, Name) 
	VALUES ('1b162191-e0d4-40a2-872e-816b0dfcc09b', 'Servidor de E-Mail'),
		   ('2015d6b5-b99f-4a28-8fba-312ef49d1ad3', 'Active Directory'),
		   ('33fc2cdf-1ce7-44e0-ac32-8a235c25c217', 'Culinária App'),
		   ('401e3053-e1f9-445f-bf14-57a0b2c349e4', 'Estoque App');
GO

INSERT INTO PersonProject(Id, ProjectId, PersonId) 
	VALUES ('17b94c1f-fa6e-46d6-82d3-f28ff5af7e17', '1b162191-e0d4-40a2-872e-816b0dfcc09b', '1aab120b-ed08-49e0-939e-16ec24bf2130'), 
		   ('2a179cfb-71b0-4c3a-9666-72309503d815', '2015d6b5-b99f-4a28-8fba-312ef49d1ad3', '24dfeba1-27b0-4d64-b30f-044d5eb44786'), 
		   ('38e96476-35e2-478a-bcff-042e40aab47c', '33fc2cdf-1ce7-44e0-ac32-8a235c25c217', '3c04c499-996c-4dd0-b24e-3b8510fdbccf'), 
		   ('4136e680-4572-481b-acc1-adb1a34bf112', '401e3053-e1f9-445f-bf14-57a0b2c349e4', '4239a808-87cc-45a7-8987-0f87249bcb4c'), 
		   ('5fe380b9-0d24-49a3-9dfe-0c5e66aebbd3', '33fc2cdf-1ce7-44e0-ac32-8a235c25c217', '4239a808-87cc-45a7-8987-0f87249bcb4c'), 
		   ('681f1c83-b0ef-4e60-9222-8cd9040fe0ae', '401e3053-e1f9-445f-bf14-57a0b2c349e4', '24dfeba1-27b0-4d64-b30f-044d5eb44786'), 
		   ('7aa3ada4-ea50-49e8-8aca-9653a2e9bcfe', '2015d6b5-b99f-4a28-8fba-312ef49d1ad3', '3c04c499-996c-4dd0-b24e-3b8510fdbccf'), 
		   ('811151e1-22e2-45ca-b6ae-d16f69e5a733', '1b162191-e0d4-40a2-872e-816b0dfcc09b', '24dfeba1-27b0-4d64-b30f-044d5eb44786');
GO

INSERT INTO Priority(Id, Description) 
	VALUES ('19b9cd1a-e444-47ed-a646-581ec731f195', 'Low'),
           ('27111b9b-8653-4f4c-af65-5e5fe8ffe565', 'Default'),
           ('3b5c5ea3-cffb-4d36-a80d-427d7d24195c', 'Hight');
GO

INSERT INTO Ticket(Id, [Description], PersonId, PriorityId, ProjectId) 
	VALUES ('b272486f-8173-439a-9c50-1ca728f76388', 'Create Email', '1aab120b-ed08-49e0-939e-16ec24bf2130', '27111b9b-8653-4f4c-af65-5e5fe8ffe565', '1b162191-e0d4-40a2-872e-816b0dfcc09b'), 
		   ('c8d61a46-01f5-4e1a-bfbd-3db9a10e96fb', 'Format Windows', '1aab120b-ed08-49e0-939e-16ec24bf2130', '19b9cd1a-e444-47ed-a646-581ec731f195', '2015d6b5-b99f-4a28-8fba-312ef49d1ad3'), 
		   ('79467146-52a1-4fc1-9804-f5d3e9d216c5', 'Install VS', '24dfeba1-27b0-4d64-b30f-044d5eb44786', '3b5c5ea3-cffb-4d36-a80d-427d7d24195c', '33fc2cdf-1ce7-44e0-ac32-8a235c25c217'),
		   ('a09598e4-2fd5-48d4-9a5f-baf84f776744', 'Server AD Blue screen', '4239a808-87cc-45a7-8987-0f87249bcb4c', '3b5c5ea3-cffb-4d36-a80d-427d7d24195c', '2015d6b5-b99f-4a28-8fba-312ef49d1ad3'),
		   ('5c4d1e1c-90a9-48fe-9131-6e29c15feca7', 'Install notepad++', '3c04c499-996c-4dd0-b24e-3b8510fdbccf', '19b9cd1a-e444-47ed-a646-581ec731f195', '33fc2cdf-1ce7-44e0-ac32-8a235c25c217'),
		   ('cf9a1a1f-fb51-487e-aa86-290e38e87a52', 'Create AD user', '24dfeba1-27b0-4d64-b30f-044d5eb44786', '27111b9b-8653-4f4c-af65-5e5fe8ffe565', '2015d6b5-b99f-4a28-8fba-312ef49d1ad3'), 
		   ('670d471a-e640-4adf-b65e-3a69adfd80d4', 'Install office 2019', '1aab120b-ed08-49e0-939e-16ec24bf2130', '3b5c5ea3-cffb-4d36-a80d-427d7d24195c', null), 
		   ('785b637a-c080-44c9-9d25-e0cfd9211e01', 'Verify wi-fi', '1aab120b-ed08-49e0-939e-16ec24bf2130', '19b9cd1a-e444-47ed-a646-581ec731f195', '2015d6b5-b99f-4a28-8fba-312ef49d1ad3'),
		   ('0fc7871f-9e9d-4096-9649-50581c4f1afa', 'Blue screen issue', '3c04c499-996c-4dd0-b24e-3b8510fdbccf', '3b5c5ea3-cffb-4d36-a80d-427d7d24195c', null),
		   ('22c9b520-74de-4abc-8ba4-890a1bd0c204', 'Install SQL Server', '3c04c499-996c-4dd0-b24e-3b8510fdbccf', '27111b9b-8653-4f4c-af65-5e5fe8ffe565', '33fc2cdf-1ce7-44e0-ac32-8a235c25c217');
GO