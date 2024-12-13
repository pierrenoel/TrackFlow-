CREATE TABLE [Fuels] (
    [Type] varchar(10) NOT NULL,
    CONSTRAINT [PK_Fuels] PRIMARY KEY ([Type])
);
GO


CREATE TABLE [Vehicles] (
    [Registration] varchar(10) NOT NULL,
    [Capicity] float NOT NULL,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY ([Registration])
);
GO


