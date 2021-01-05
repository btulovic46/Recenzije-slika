CREATE TABLE [dbo].[Review] (
    [Id]      INT            NOT NULL,
    [Comment] NVARCHAR (250) NOT NULL,
    [Grade]   REAL           NOT NULL,
    [ReviewerId] INT NULL, 
    [PictureId] INT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Review_Reviewer] FOREIGN KEY ([ReviewerId]) REFERENCES [Reviewer]([Id]), 
    CONSTRAINT [FK_Review_Picture] FOREIGN KEY ([PictureId]) REFERENCES [Picture]([Id])
);
