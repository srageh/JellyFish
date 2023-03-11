﻿CREATE TABLE Job (
job_id int IDENTITY NOT NULL, 
title nvarchar(255) NOT NULL,
salary NUMERIC(10,2) NOT NULL,
status nvarchar(255) NOT NULL,
createdDate DATETIME2 NULL, 
location NVARCHAR(50) NULL, 
category_id int NOT NULL,
job_type_id int NOT NULL,
level_id int NOT  NULL,
employer_id nvarchar(450) NOT NULL,
description nvarchar(255) NOT NULL, 


PRIMARY KEY (job_id),
CONSTRAINT fk_category FOREIGN KEY (category_id) REFERENCES Category (category_id),
CONSTRAINT fk_job_type FOREIGN KEY (job_type_id) REFERENCES JobType (job_type_id),
CONSTRAINT fk_employer FOREIGN KEY (employer_id) REFERENCES Employer (employer_id),
CONSTRAINT fk_level FOREIGN KEY (level_id) REFERENCES Level([Id])
);