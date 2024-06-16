-- Testing
select * from employees

select * from departments

select a.employee_id, a.first_name,a.hire_date,b.department_name
from employees a left join departments b
on a.department_id = b.department_id