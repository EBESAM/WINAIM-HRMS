-- Insert dummy data into departments table
INSERT INTO departments (department_name) VALUES 
('Human Resources'),
('Engineering'),
('Marketing'),
('Sales');

-- Insert dummy data into roles table
INSERT INTO roles (role_name) VALUES 
('Manager'),
('Developer'),
('Analyst'),
('Sales Representative');

-- Insert dummy data into employees table
INSERT INTO employees (first_name, last_name, department_id, hire_date, role_id) VALUES 
('John', 'Doe', 2, '2020-01-15', 2),
('Jane', 'Smith', 1, '2019-11-20', 1),
('Emily', 'Johnson', 3, '2021-06-10', 3),
('Michael', 'Brown', 4, '2018-09-25', 4),
('Linda', 'Davis', 2, '2017-03-30', 2),
('James', 'Wilson', 3, '2016-12-01', 3),
('Patricia', 'Taylor', 1, '2015-07-19', 1),
('Robert', 'Anderson', 4, '2022-03-17', 4);

-- Insert dummy data into performance_reviews table
INSERT INTO performance_reviews (employee_id, review_date, review_text) VALUES 
(1, '2022-12-15', 'Outstanding performance throughout the year.'),
(2, '2022-11-20', 'Met all targets and showed great leadership.'),
(3, '2023-01-10', 'Excellent analytical skills and attention to detail.'),
(4, '2022-09-25', 'Consistently exceeded sales targets.'),
(5, '2021-03-30', 'Great technical skills, needs improvement in communication.'),
(6, '2021-12-01', 'Performed well in all assigned tasks.'),
(7, '2020-07-19', 'Excellent management skills, highly recommended for promotion.'),
(8, '2023-03-17', 'New hire, showed great potential in the initial months.');
