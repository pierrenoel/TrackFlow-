CREATE TABLE [Drivers] (
    [Id] uniqueidentifier NOT NULL,
    [Firstname] varchar(10) NOT NULL,
    [Lastname] varchar(10) NOT NULL,
    CONSTRAINT [PK_Drivers] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Vehicles] (
    [Registration] varchar(10) NOT NULL,
    [Capacity] float NOT NULL,
    [Fuel] varchar(10) NOT NULL,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY ([Registration])
);
GO


CREATE TABLE [Iteneraries] (
    [VehicleId] varchar(10) NOT NULL,
    [DriverId] uniqueidentifier NOT NULL,
    [DateStart] datetime2 NOT NULL,
    [DateEnd] datetime2 NOT NULL,
    CONSTRAINT [PK_Iteneraries] PRIMARY KEY ([DriverId], [VehicleId]),
    CONSTRAINT [FK_Iteneraries_Drivers_DriverId] FOREIGN KEY ([DriverId]) REFERENCES [Drivers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Iteneraries_Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicles] ([Registration]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_Iteneraries_VehicleId] ON [Iteneraries] ([VehicleId]);
GO


