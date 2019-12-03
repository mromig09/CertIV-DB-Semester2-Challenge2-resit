CREATE TABLE [dbo].[sale]
(
	[dateOrdered] DATE NOT NULL, 
    [price] MONEY NOT NULL, 
    [cdID] VARCHAR(10) NOT NULL, 
    [clientNumber] INT NOT NULL, 
    [passionCode] VARCHAR(10) NOT NULL
	PRIMARY KEY ([dateOrdered], [cdID], [clientNumber]),
	FOREIGN KEY ([cdID]) REFERENCES [dbo].[cd],
	FOREIGN KEY ([clientNumber], [passionCode]) REFERENCES [dbo].[clients]
)
