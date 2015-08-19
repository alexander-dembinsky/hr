USE [HR]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Images]
(
    [Id] [uniqueidentifier] NOT NULL,
	Content image NOT NULL,
	ContentType text NOT NULL,
	ContentLength bigint not null,
	[FileName] text not null,
	PRIMARY KEY ([Id])
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];

CREATE TABLE [dbo].[InfoType]
(
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [text] NOT NULL,
	[Mask] [text] NULL,
	[Group] [int] NOT NULL,
	ImageId [uniqueidentifier],
	Active bit DEFAULT 1 NOT NULL,
	PRIMARY KEY([Id]),
	CONSTRAINT InfoType_Image_FK FOREIGN KEY (ImageId) REFERENCES [dbo].[Images](Id)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

insert into [dbo].[InfoType] (Id,Name, Mask, [Group]) values (NEWID(),'Work Phone', NULL, 1);
insert into [dbo].[InfoType] (Id,Name, Mask, [Group]) values (NEWID(),'Home Phone', NULL, 1);
insert into [dbo].[InfoType] (Id,Name, Mask, [Group]) values (NEWID(),'Google+', NULL,0);
insert into [dbo].[InfoType] (Id,Name, Mask, [Group]) values (NEWID(),'VK', NULL, 0);
insert into [dbo].[InfoType] (Id,Name, Mask, [Group]) values (NEWID(),'Facebook', NULL, 0);
insert into [dbo].[InfoType] (Id,Name, Mask, [Group]) values (NEWID(),'LinkedIn', NULL, 0);

GO
