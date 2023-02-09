CREATE TABLE Company (company_id int IDENTITY NOT NULL, employer_id nvarchar(450) NOT NULL, name int NULL, url int NULL, PRIMARY KEY (company_id));
GO
ALTER TABLE Company ADD CONSTRAINT FKCompany237877 FOREIGN KEY (employer_id) REFERENCES Employer (employer_id);