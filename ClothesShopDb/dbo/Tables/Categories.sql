CREATE TABLE [dbo].[Categories] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [NameUZ]        NVARCHAR (MAX) NOT NULL,
    [NameRU]        NVARCHAR (MAX) NOT NULL,
    [NameEN]        NVARCHAR (MAX) NOT NULL,
    [DescriptionUZ] NVARCHAR (MAX) NULL,
    [DescriptionRU] NVARCHAR (MAX) NULL,
    [DescriptionEN] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

