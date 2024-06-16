-- To Find all employees who have been hired in the last year
SELECT * 
FROM employees
WHERE hire_date >= CURDATE() - INTERVAL 1 YEAR;

--   To Calculate the total salary expenditure for each department
SELECT d.department_name, SUM(s.salary) AS total_salary_expenditure
FROM employees e
JOIN departments d ON e.department_id = d.department_id
JOIN salaries s ON e.employee_id = s.employee_id
GROUP BY d.department_name;

-- To Find the top 5 highest-paid employees along with their department names 
SELECT e.first_name, e.last_name, d.department_name, s.salary
FROM employees e
JOIN departments d ON e.department_id = d.department_id
JOIN (
    SELECT employee_id, MAX(salary) AS salary
    FROM salaries
    GROUP BY employee_id
) s ON e.employee_id = s.employee_id
ORDER BY s.salary DESC
LIMIT 5;