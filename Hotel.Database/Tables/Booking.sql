﻿CREATE TABLE [dbo].[Booking]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerId] INT NOT NULL FOREIGN KEY REFERENCES Customer(Id), 
    [RoomId] INT NOT NULL FOREIGN KEY REFERENCES Room(Id), 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NOT NULL, 
    [TotalCost] DECIMAL(18, 2) NOT NULL
)