using New_WebApllication.DAL;
using New_WebApllication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace New_WebApllication.Controllers
{
    public class EmployeesController : ApiController
    {
        private HRMSContext db = new HRMSContext();

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            return db.GetEmployees();
        }

        // GET: api/Employees/5
        [HttpGet]
        public IHttpActionResult GetEmployee(int id)
        {
            var employee = db.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST: api/Employees
        [HttpPost]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.AddEmployee(employee);
            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeId }, employee);
        }

        // PUT: api/Employees/5
        [HttpPut]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }
            db.UpdateEmployee(employee);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Employees/5
        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employee = db.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            db.DeleteEmployee(id);
            return Ok(employee);
        }
    }
}
