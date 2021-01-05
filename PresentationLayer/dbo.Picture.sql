CREATE TABLE [dbo].[Picture] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (10) NOT NULL,
    [Creator]      NVARCHAR (10) NOT NULL,
    [Description]  NVARCHAR (10) NOT NULL,
    [AverageGrade] REAL          NULL,
    [GalleryId] INT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Picture_Gallery] FOREIGN KEY ([GalleryId]) REFERENCES [Gallery]([Id])
);

