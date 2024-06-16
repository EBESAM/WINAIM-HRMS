-- Create the employees table
CREATE TABLE employees (
    employee_id INT NOT NULL AUTO_INCREMENT,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    department_id INT,
    role_id INT,
    hire_date DATE NOT NULL,
    PRIMARY KEY (employee_id),
    FOREIGN KEY (department_id) REFERENCES departments(department_id),
    FOREIGN KEY (role_id) REFERENCES roles(role_id)
);

-- Create the departments table
CREATE TABLE departments (
    department_id INT NOT NULL AUTO_INCREMENT,
    department_name VARCHAR(100) NOT NULL,
    PRIMARY KEY (department_id)
);

-- Create the roles table
CREATE TABLE roles (
    role_id INT NOT NULL AUTO_INCREMENT,
    role_name VARCHAR(50) NOT NULL,
    PRIMARY KEY (role_id)
);

-- Create the performance_reviews table
CREATE TABLE performance_reviews (
    review_id INT NOT NULL AUTO_INCREMENT,
    employee_id INT NOT NULL,
    review_date DATE NOT NULL,
    review_text TEXT,
    PRIMARY KEY (review_id),
    FOREIGN KEY (employee_id) REFERENCES employees(employee_id)
);
