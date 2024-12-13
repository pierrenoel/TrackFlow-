CREATE TABLE [Drivers] (
    [Id] uniqueidentifier NOT NULL,
    [Firstname] varchar(10) NOT NULL,
    [Lastname] varchar(10) NOT NULL,
    CONSTRAINT [PK_Drivers] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Vehicles] (
    [IdDriver] uniqueidentifier NOT NULL,
    [Registration] varchar(10) NULL,
    [Capacity] float NOT NULL,
    [Fuel] varchar(10) NOT NULL,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY ([IdDriver])
);
GO


