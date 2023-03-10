-- Insert a new job
INSERT INTO Job (title, salary, status, category_id, job_type_id, level_id, employer_id, description)
VALUES ('Software Engineer', 80000.00, 'Open', 41, 22,1, 'd7ec3b92-4ec2-407e-b8cc-817b04da14d9', 'We are looking for a skilled software engineer to join our team.');
INSERT INTO Job (title, salary, status, category_id, job_type_id, level_id, employer_id, description)
VALUES ('JR Software Engineer', 60000.00, 'Open',42, 23,2, 'd7ec3b92-4ec2-407e-b8cc-817b04da14d9', 'We are seeking a talented marketing manager to lead our marketing efforts.');
INSERT INTO Job (title, salary, status, category_id, job_type_id, level_id, employer_id, description)
VALUES ('Intern Software Engineer', 50000.00, 'Open', 43, 24,3, 'd7ec3b92-4ec2-407e-b8cc-817b04da14d9', 'We need an energetic sales representative to grow our customer base.');


Insert into Category(name) VALUES ('Fullstack');
Insert into Category(name) VALUES ('FrontEnd');
Insert into Category(name) VALUES ('BackEnd');

Insert into JobType(name) VALUES ('fulltime');
Insert into JobType(name) VALUES ('partime');
Insert into JobType(name) VALUES ('contract');


delete from Category;

delete from JobType;





