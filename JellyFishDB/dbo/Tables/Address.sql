CREATE TABLE Address (address_id int IDENTITY NOT NULL, street nvarchar(255) NULL, city nvarchar(255) NULL, postal_code nvarchar(255) NULL, province nvarchar(255) NULL, user_id nvarchar(450) NOT NULL, PRIMARY KEY (address_id));
GO
ALTER TABLE Address ADD CONSTRAINT FKAddress726313 FOREIGN KEY (user_id) REFERENCES dbo.AspNetUsers (Id);