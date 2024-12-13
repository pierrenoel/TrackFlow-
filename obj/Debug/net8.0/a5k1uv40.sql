CREATE TABLE [Fuels] (
    [Type] varchar(10) NOT NULL,
    CONSTRAINT [PK_Fuels] PRIMARY KEY ([Type])
);
GO


CREATE TABLE [Vehicles] (
    [Registration] varchar(10) NOT NULL,
    [Capicity] float NOT NULL,
    [FuelType] varchar(10) NOT NULL,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY ([Registration]),
    CONSTRAINT [FK_Vehicles_Fuels_FuelType] FOREIGN KEY ([FuelType]) REFERENCES [Fuels] ([Type]) ON DELETE CASCADE
);
GO


CREATE UNIQUE INDEX [IX_Vehicles_FuelType] ON [Vehicles] ([FuelType]);
GO


