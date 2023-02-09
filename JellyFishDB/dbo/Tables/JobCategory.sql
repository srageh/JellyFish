CREATE TABLE JobCategory (job_category_id int IDENTITY NOT NULL, job_id int NOT NULL, category_id int NOT NULL, PRIMARY KEY (job_category_id));
GO
ALTER TABLE JobCategory ADD CONSTRAINT FKJobCategor238289 FOREIGN KEY (job_id) REFERENCES Job (job_id);
GO
ALTER TABLE JobCategory ADD CONSTRAINT FKJobCategor418821 FOREIGN KEY (category_id) REFERENCES Category (category_id);