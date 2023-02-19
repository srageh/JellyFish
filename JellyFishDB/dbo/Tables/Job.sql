CREATE TABLE Job (
job_id int IDENTITY NOT NULL, 
title nvarchar(255) NOT NULL,
description nvarchar(255) NOT NULL, 

PRIMARY KEY (job_id));