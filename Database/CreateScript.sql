USE [HR]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InfoType](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [text] NOT NULL,
	[Mask] [text] NULL,
	[Group] [int] NOT NULL,
	PRIMARY KEY([Id]),
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

insert into [dbo].[InfoType] (Id,Name, Mask, [Group]) values (NEWID(),'Work Phone', NULL, 1);
insert into [dbo].[InfoType] (Id,Name, Mask, [Group]) values (NEWID(),'Home Phone', NULL, 1);
insert into [dbo].[InfoType] (Id,Name, Mask, [Group]) values (NEWID(),'Google+', NULL, 0);
insert into [dbo].[InfoType] (Id,Name, Mask, [Group]) values (NEWID(),'VK', '(http|https)://vk.com/[a-zA-Z0-9]+', 0);
insert into [dbo].[InfoType] (Id,Name, Mask, [Group]) values (NEWID(),'Facebook', NULL, 0);
insert into [dbo].[InfoType] (Id,Name, Mask, [Group]) values (NEWID(),'LinkedIn', NULL, 0);

GO
