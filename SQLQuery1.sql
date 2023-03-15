insert into level (Level_name) VALUES ('Junior');
insert into level (Level_name) VALUES ('Mid-Level');
insert into level (Level_name) VALUES ('Senior');

Insert into Category(name) VALUES ('Fullstack');
Insert into Category(name) VALUES ('FrontEnd');
Insert into Category(name) VALUES ('BackEnd');

Insert into JobType(name) VALUES ('fulltime');
Insert into JobType(name) VALUES ('partime');
Insert into JobType(name) VALUES ('contract');

-- Insert a new job
INSERT INTO Job (title, salary, status, category_id, job_type_id, level_id, employer_id, description)
VALUES ('Software Engineer', 80000.00, 'Open', 1, 1,1, 'e37abef5-cc12-4635-ba13-a004976074f1', 'We are looking for a skilled software engineer to join our team.');
INSERT INTO Job (title, salary, status, category_id, job_type_id, level_id, employer_id, description)
VALUES ('JR Software Engineer', 60000.00, 'Open',2, 2,2, 'e37abef5-cc12-4635-ba13-a004976074f1', 'We are seeking a talented marketing manager to lead our marketing efforts.');
INSERT INTO Job (title, salary, status, category_id, job_type_id, level_id, employer_id, description)
VALUES ('Intern Software Engineer', 50000.00, 'Open', 3, 3,3, 'e37abef5-cc12-4635-ba13-a004976074f1', 'We need an energetic sales representative to grow our customer base.');





delete from Category;

delete from JobType;





