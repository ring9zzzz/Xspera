CREATE TABLE [dbo].[User] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Type]        INT           NOT NULL,
    [Username]    NVARCHAR (25) NOT NULL,
    [Email]       NVARCHAR (50) NOT NULL,
    [DateOfBirth] DATETIME      NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

