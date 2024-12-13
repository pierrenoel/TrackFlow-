CREATE TABLE [Drivers] (
    [Id] uniqueidentifier NOT NULL,
    [Firstname] varchar(10) NOT NULL,
    [Lastname] varchar(10) NOT NULL,
    CONSTRAINT [PK_Drivers] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Vehicles] (
    [Registration] varchar(10) NOT NULL,
    [IdDriver] uniqueidentifier NOT NULL,
    [Capacity] float NOT NULL,
    [Fuel] varchar(10) NOT NULL,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY ([Registration], [IdDriver]),
    CONSTRAINT [FK_Vehicles_Drivers_IdDriver] FOREIGN KEY ([IdDriver]) REFERENCES [Drivers] ([Id]) ON DELETE CASCADE
);
GO


CREATE UNIQUE INDEX [IX_Vehicles_IdDriver] ON [Vehicles] ([IdDriver]);
GO


