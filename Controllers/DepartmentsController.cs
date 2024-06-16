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
    public class DepartmentsController : ApiController
    {
        private HRMSContext db = new HRMSContext();

        // GET: api/Departments
        [HttpGet]
        public IEnumerable<Department> GetDepartments()
        {
            return db.GetDepartments();
        }

        // GET: api/Departments/5
        [HttpGet]
        public IHttpActionResult GetDepartment(int id)
        {
            var department = db.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        // POST: api/Departments
        [HttpPost]
        public IHttpActionResult PostDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.AddDepartment(department);
            return CreatedAtRoute("DefaultApi", new { id = department.DepartmentId }, department);
        }

        // PUT: api/Departments/5
        [HttpPut]
        public IHttpActionResult PutDepartment(int id, Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }
            db.UpdateDepartment(department);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Departments/5
        [HttpDelete]
        public IHttpActionResult DeleteDepartment(int id)
        {
            var department = db.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            db.DeleteDepartment(id);
            return Ok(department);
        }
    }
}
