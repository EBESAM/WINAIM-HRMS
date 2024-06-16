-- Insert sample data into departments
INSERT INTO departments (department_name) VALUES ('HR'), ('Finance'), ('IT'), ('Marketing'),
 ('Research and Development'), ('Customer Support'), ('Sales');

-- Insert sample data into employees
INSERT INTO employees (first_name, last_name, department_id, hire_date) 
VALUES ('Kishore', 'M', 1, '2023-06-10'),
       ('Gopi', 'J', 2, '2022-03-15'),
       ('Moneshwar', 'V', 3, '2024-01-05'),
       ('Nishanth', 'CP', 4, '2021-11-20'),
       ('Shree', 'B', 5, '2023-04-01'),
       ('Ebesam', 'S', 6, '2023-05-15'),
       ('Vidhya', 'S', 7, '2022-09-10'),
       ('Bala', 'T', 1, '2023-07-23'),
       ('Dinesh', 'S', 2, '2021-12-30'),
       ('Augustin', 'J', 3, '2022-11-11'),
       ('Peter', 'A', 4, '2024-02-20');
       
-- Insert sample data into salaries
INSERT INTO salaries (employee_id, salary, from_date, to_date) 
VALUES (1, 50000.00, '2023-06-10', NULL),
       (2, 60000.00, '2022-03-15', NULL),
       (3, 70000.00, '2024-01-05', NULL),
       (4, 80000.00, '2021-11-20', NULL),
       (5, 55000.00, '2023-04-01', NULL),
       (6, 62000.00, '2023-05-15', NULL),
	   (7, 45000.00, '2022-09-10', NULL),
	   (8, 51000.00, '2023-07-23', NULL),
       (9, 58000.00, '2021-12-30', NULL),
       (10, 67000.00, '2022-11-11', NULL),
       (11, 76000.00, '2024-02-20', NULL);
       
       
commit

