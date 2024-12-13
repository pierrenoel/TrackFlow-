CREATE TABLE [Fuels] (
    [Type] varchar(10) NOT NULL,
    CONSTRAINT [PK_Fuels] PRIMARY KEY ([Type])
);
GO


CREATE TABLE [Vehicles] (
    [Registration] varchar(10) NOT NULL,
    [Capacity] float NOT NULL,
    [FuelType] varchar(10) NOT NULL,
    [FuelType1] varchar(10) NULL,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY ([Registration]),
    CONSTRAINT [FK_Vehicles_Fuels_FuelType] FOREIGN KEY ([FuelType]) REFERENCES [Fuels] ([Type]),
    CONSTRAINT [FK_Vehicles_Fuels_FuelType1] FOREIGN KEY ([FuelType1]) REFERENCES [Fuels] ([Type])
);
GO


CREATE UNIQUE INDEX [IX_Vehicles_FuelType] ON [Vehicles] ([FuelType]);
GO


CREATE INDEX [IX_Vehicles_FuelType1] ON [Vehicles] ([FuelType1]);
GO


