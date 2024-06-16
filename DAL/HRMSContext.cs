using MySql.Data.MySqlClient;
using New_WebApllication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace New_WebApllication.DAL
{
    public class HRMSContext
    {
            private string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;

            public IEnumerable<Employee> GetEmployees()
            {
                var employees = new List<Employee>();
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "SELECT * FROM employees";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employees.Add(new Employee
                                {
                                    EmployeeId = reader.GetInt32("employee_id"),
                                    FirstName = reader.GetString("first_name"),
                                    LastName = reader.GetString("last_name"),
                                    DepartmentId = reader.GetInt32("department_id"),
                                    RoleId = reader.GetInt32("role_id"),
                                    HireDate = reader.GetDateTime("hire_date")
                                });
                            }
                        }
                    }
                }
                return employees;
            }

            public Employee GetEmployeeById(int id)
            {
                Employee employee = null;
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "SELECT * FROM employees WHERE employee_id = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                employee = new Employee
                                {
                                    EmployeeId = reader.GetInt32("employee_id"),
                                    FirstName = reader.GetString("first_name"),
                                    LastName = reader.GetString("last_name"),
                                    DepartmentId = reader.GetInt32("department_id"),
                                    RoleId = reader.GetInt32("role_id"),
                                    HireDate = reader.GetDateTime("hire_date")
                                };
                            }
                        }
                    }
                }
                return employee;
            }

            public void AddEmployee(Employee employee)
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "INSERT INTO employees (first_name, last_name, department_id, role_id, hire_date) VALUES (@FirstName, @LastName, @DepartmentId, @RoleId, @HireDate)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                        cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                        cmd.Parameters.AddWithValue("@RoleId", employee.RoleId);
                        cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public void UpdateEmployee(Employee employee)
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "UPDATE employees SET first_name = @FirstName, last_name = @LastName, department_id = @DepartmentId, role_id = @RoleId, hire_date = @HireDate WHERE employee_id = @EmployeeId";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                        cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                        cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                        cmd.Parameters.AddWithValue("@RoleId", employee.RoleId);
                        cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public void DeleteEmployee(int id)
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "DELETE FROM employees WHERE employee_id = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public IEnumerable<Department> GetDepartments()
            {
                var departments = new List<Department>();
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "SELECT * FROM departments";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                departments.Add(new Department
                                {
                                    DepartmentId = reader.GetInt32("department_id"),
                                    DepartmentName = reader.GetString("department_name")
                                });
                            }
                        }
                    }
                }
                return departments;
            }

            public Department GetDepartmentById(int id)
            {
                Department department = null;
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "SELECT * FROM departments WHERE department_id = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                department = new Department
                                {
                                    DepartmentId = reader.GetInt32("department_id"),
                                    DepartmentName = reader.GetString("department_name")
                                };
                            }
                        }
                    }
                }
                return department;
            }

            public void AddDepartment(Department department)
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "INSERT INTO departments (department_name) VALUES (@DepartmentName)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public void UpdateDepartment(Department department)
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "UPDATE departments SET department_name = @DepartmentName WHERE department_id = @DepartmentId";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentId", department.DepartmentId);
                        cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public void DeleteDepartment(int id)
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "DELETE FROM departments WHERE department_id = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public IEnumerable<Role> GetRoles()
            {
                var roles = new List<Role>();
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "SELECT * FROM roles";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                roles.Add(new Role
                                {
                                    RoleId = reader.GetInt32("role_id"),
                                    RoleName = reader.GetString("role_name")
                                });
                            }
                        }
                    }
                }
                return roles;
            }

            public Role GetRoleById(int id)
            {
                Role role = null;
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "SELECT * FROM roles WHERE role_id = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                role = new Role
                                {
                                    RoleId = reader.GetInt32("role_id"),
                                    RoleName = reader.GetString("role_name")
                                };
                            }
                        }
                    }
                }
                return role;
            }

            public void AddRole(Role role)
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "INSERT INTO roles (role_name) VALUES (@RoleName)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoleName", role.RoleName);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public void UpdateRole(Role role)
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "UPDATE roles SET role_name = @RoleName WHERE role_id = @RoleId";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoleId", role.RoleId);
                        cmd.Parameters.AddWithValue("@RoleName", role.RoleName);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public void DeleteRole(int id)
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "DELETE FROM roles WHERE role_id = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public IEnumerable<PerformanceReview> GetPerformanceReviews()
            {
                var reviews = new List<PerformanceReview>();
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "SELECT * FROM performance_reviews";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reviews.Add(new PerformanceReview
                                {
                                    ReviewId = reader.GetInt32("review_id"),
                                    EmployeeId = reader.GetInt32("employee_id"),
                                    ReviewDate = reader.GetDateTime("review_date"),
                                    ReviewText = reader.GetString("review_text")
                                });
                            }
                        }
                    }
                }
                return reviews;
            }

            public PerformanceReview GetPerformanceReviewById(int id)
            {
                PerformanceReview review = null;
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "SELECT * FROM performance_reviews WHERE review_id = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                review = new PerformanceReview
                                {
                                    ReviewId = reader.GetInt32("review_id"),
                                    EmployeeId = reader.GetInt32("employee_id"),
                                    ReviewDate = reader.GetDateTime("review_date"),
                                    ReviewText = reader.GetString("review_text")
                                };
                            }
                        }
                    }
                }
                return review;
            }

            public void AddPerformanceReview(PerformanceReview review)
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "INSERT INTO performance_reviews (employee_id, review_date, review_text) VALUES (@EmployeeId, @ReviewDate, @ReviewText)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeId", review.EmployeeId);
                        cmd.Parameters.AddWithValue("@ReviewDate", review.ReviewDate);
                        cmd.Parameters.AddWithValue("@ReviewText", review.ReviewText);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public void UpdatePerformanceReview(PerformanceReview review)
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "UPDATE performance_reviews SET employee_id = @EmployeeId, review_date = @ReviewDate, review_text = @ReviewText WHERE review_id = @ReviewId";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReviewId", review.ReviewId);
                        cmd.Parameters.AddWithValue("@EmployeeId", review.EmployeeId);
                        cmd.Parameters.AddWithValue("@ReviewDate", review.ReviewDate);
                        cmd.Parameters.AddWithValue("@ReviewText", review.ReviewText);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public void DeletePerformanceReview(int id)
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "DELETE FROM performance_reviews WHERE review_id = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }


