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
    public class RolesController : ApiController
    {
        private HRMSContext db = new HRMSContext();

        // GET: api/Roles
        [HttpGet]
        public IEnumerable<Role> GetRoles()
        {
            return db.GetRoles();
        }

        // GET: api/Roles/5
        [HttpGet]
        public IHttpActionResult GetRole(int id)
        {
            var role = db.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        // POST: api/Roles
        [HttpPost]
        public IHttpActionResult PostRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.AddRole(role);
            return CreatedAtRoute("DefaultApi", new { id = role.RoleId }, role);
        }

        // PUT: api/Roles/5
        [HttpPut]
        public IHttpActionResult PutRole(int id, Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != role.RoleId)
            {
                return BadRequest();
            }
            db.UpdateRole(role);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Roles/5
        [HttpDelete]
        public IHttpActionResult DeleteRole(int id)
        {
            var role = db.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }
            db.DeleteRole(id);
            return Ok(role);
        }
    }
}
