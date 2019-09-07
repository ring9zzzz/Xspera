CREATE TABLE [dbo].[Review] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ProductId]   INT            NOT NULL,
    [UserId]      INT            NOT NULL,
    [Rating]      INT            NOT NULL,
    [Comment]     NVARCHAR (MAX) NULL,
    [Email]       NVARCHAR (30)  NOT NULL,
    [DateCreated] DATETIME       NOT NULL,
    CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Review_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_Review_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);



