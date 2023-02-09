CREATE TABLE Employer (employer_id nvarchar(450) NOT NULL, title nvarchar(255) NOT NULL, PRIMARY KEY (employer_id));
GO
ALTER TABLE Employer ADD CONSTRAINT FKEmployer37240 FOREIGN KEY (employer_id) REFERENCES dbo.AspNetUsers (Id);