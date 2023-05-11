USE kalvad;
GO

IF OBJECT_ID('dbo.Customers') IS NOT NULL
    BEGIN
        DROP TABLE dbo.Customers;
END;
GO

IF OBJECT_ID('dbo.Addresses') IS NOT NULL
    BEGIN
        DROP TABLE dbo.Addresses;
END;
GO

CREATE TABLE [dbo].[Customers](
	[Id]                NVARCHAR(50) NOT NULL, 
    [FirstName]			NVARCHAR(max) NOT NULL,
	[LastName]			NVARCHAR(max) NOT NULL,
	[PhoneNumber]		NVARCHAR(max) NOT NULL,
	[Email]				NVARCHAR(max) NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED([Id] ASC)
);
GO

CREATE TABLE [dbo].[Addresses](
	[Id]                NVARCHAR(50) NOT NULL, 
    [TypeOfAddress]     NVARCHAR(max) NOT NULL,
	[City]              NVARCHAR(max) NOT NULL,
	[Country]           NVARCHAR(max) NOT NULL,
	[AddressLine]       NVARCHAR(max) NOT NULL,
	[CustomerId]        NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED([Id] ASC), 
	CONSTRAINT [FK_Addresses_CustomerId] FOREIGN KEY([CustomerId]) REFERENCES [Customers]([Id])
);
GO