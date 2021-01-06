CREATE TABLE [dbo].[Picture] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (30) NOT NULL,
    [Creator]      NVARCHAR (30) NOT NULL,
    [Description]  NVARCHAR (250) NOT NULL,
    [AverageGrade] FLOAT          NULL,
    [GalleryId]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Picture_Gallery] FOREIGN KEY ([GalleryId]) REFERENCES [dbo].[Gallery] ([Id])
);

