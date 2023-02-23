-- Insert a new job
INSERT INTO Job (title, salary, status, category_id, job_type_id, employer_id, description)
VALUES ('Software Engineer', 80000.00, 'Open', 70, 1, '14b3ef10-abc7-46d8-8848-8a34fdf605a8', 'We are looking for a skilled software engineer to join our team.'); -- Insert another job
INSERT INTO Job (title, salary, status, category_id, job_type_id, employer_id, description)
VALUES ('JR Software Engineer', 60000.00, 'Open',  71, 2, '14b3ef10-abc7-46d8-8848-8a34fdf605a8', 'We are seeking a talented marketing manager to lead our marketing efforts.'); -- Insert one more job
INSERT INTO Job (title, salary, status, category_id, job_type_id, employer_id, description)
VALUES ('Intern Software Engineer', 50000.00, 'Open', 72, 3, '14b3ef10-abc7-46d8-8848-8a34fdf605a8', 'We need an energetic sales representative to grow our customer base.');  Insert into Category(name) VALUES ('Fullstack');
Insert into Category(name) VALUES ('FrontEnd');
Insert into Category(name) VALUES ('BackEnd'); 
Insert into JobType(name) VALUES ('fulltime');
Insert into JobType(name) VALUES ('partime');
Insert into JobType(name) VALUES ('contract');