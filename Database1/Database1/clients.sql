CREATE TABLE [dbo].[clients]
(
	[clientNumber] INT NOT NULL , 
    [passionCode] VARCHAR(10) NOT NULL, 
    [name] VARCHAR(100) NOT NULL, 
    [address] VARCHAR(100) NOT NULL, 
    [postCode] INT NOT NULL, 
    PRIMARY KEY ([clientNumber], [passionCode]),
	FOREIGN KEY ([passionCode]) REFERENCES [dbo].[special_passion]
)
