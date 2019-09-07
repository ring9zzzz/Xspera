CREATE TABLE [dbo].[Product] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [BrandId]         INT            NOT NULL,
    [Name]            NVARCHAR (20)  NOT NULL,
    [Price]           MONEY          NOT NULL,
    [Color]           NVARCHAR (50)  NULL,
    [Description]     NVARCHAR (MAX) NULL,
    [DateCreated]     DATETIME       NOT NULL,
    [AvailableStatus] INT            CONSTRAINT [DF_Product_AvailableStatus] DEFAULT ((0)) NOT NULL,
    [CreatedBy]       INT            NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_Brand] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brand] ([Id])
);

