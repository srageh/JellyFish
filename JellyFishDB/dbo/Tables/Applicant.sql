CREATE TABLE Applicant (
applicant_id int IDENTITY NOT NULL,
job_id int NOT NULL,
user_id nvarchar(450) NOT NULL,
PRIMARY KEY (applicant_id));

GO
ALTER TABLE Applicant ADD CONSTRAINT FKApplicant720822 FOREIGN KEY (user_id) REFERENCES dbo.AspNetUsers (Id);
GO
ALTER TABLE Applicant ADD CONSTRAINT FKApplicant506596 FOREIGN KEY (job_id) REFERENCES Job (job_id);