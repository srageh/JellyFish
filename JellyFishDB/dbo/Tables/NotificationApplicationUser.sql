CREATE TABLE [dbo].[NotificationApplicationUser]
(
	[NotificationId] INT NOT NULL, 
    [ApplicationUserId] NVARCHAR(MAX) NULL, 
    [IsRead] BIT NULL, 
    CONSTRAINT [PK_NotificationApplicationUser] PRIMARY KEY ([NotificationId]) 
)
