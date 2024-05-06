CREATE TABLE [dbo].[Products] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [NameUZ]        NVARCHAR (MAX) NOT NULL,
    [NameEN]        NVARCHAR (MAX) NOT NULL,
    [NameRU]        NVARCHAR (MAX) NOT NULL,
    [DescriptionUZ] NVARCHAR (MAX) NULL,
    [DescriptionEN] NVARCHAR (MAX) NULL,
    [DescriptionRU] NVARCHAR (MAX) NULL,
    [Price]         FLOAT (53)     NOT NULL,
    [Gender]        BIT            NOT NULL,
    [CategoryId]    INT            NOT NULL,
    [Color]         NVARCHAR (MAX) DEFAULT (N'') NOT NULL,
    [Quantity]      INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId]
    ON [dbo].[Products]([CategoryId] ASC);

