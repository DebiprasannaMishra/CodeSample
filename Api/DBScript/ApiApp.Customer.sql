CREATE DATABASE [ApiApp]

USE [ApiApp]

CREATE TABLE [Customer] (
[Id] INT PRIMARY KEY IDENTITY(1,1), 
[Name] VARCHAR(50), 
[Location] VARCHAR(50), 
[Email] VARCHAR(50), 
[Phone] VARCHAR(50))

SELECT * FROM [Customer]

--INSERT [Customer] ([Name], [Location], [Email], [Phone]) VALUES ('Customer 1', 'Location 1', 'Email 1', 'Phone 1')
--INSERT [Customer] ([Name], [Location], [Email], [Phone]) VALUES ('Customer 2', 'Location 2', 'Email 2', 'Phone 2')
--INSERT [Customer] ([Name], [Location], [Email], [Phone]) VALUES ('Customer 3', 'Location 3', 'Email 3', 'Phone 3')