using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace New_WebApllication.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public DateTime HireDate { get; set; }
        public virtual Department Department { get; set; }
        public virtual Role Role { get; set; }
    }
}