using New_WebApllication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace New_WebApllication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient client;

        public EmployeeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44376/"); // Change to your API base address
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Employee
        public async Task<ActionResult> Index()
        {
            IEnumerable<Employee> employees = null;
            HttpResponseMessage response = await client.GetAsync("api/Employees");
            if (response.IsSuccessStatusCode)
            {
                employees = await response.Content.ReadAsAsync<IEnumerable<Employee>>();
            }
            return View(employees);
        }

        // GET: Employee/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Employee employee = null;
            HttpResponseMessage response = await client.GetAsync($"api/Employees/{id}");
            if (response.IsSuccessStatusCode)
            {
                employee = await response.Content.ReadAsAsync<Employee>();
            }
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Departments = await GetDepartments();
            ViewBag.Roles = await GetRoles();
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Employees", employee);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Departments = await GetDepartments();
            ViewBag.Roles = await GetRoles();
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Employee employee = null;
            HttpResponseMessage response = await client.GetAsync($"api/Employees/{id}");
            if (response.IsSuccessStatusCode)
            {
                employee = await response.Content.ReadAsAsync<Employee>();
            }
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Departments = await GetDepartments();
            ViewBag.Roles = await GetRoles();
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"api/Employees/{id}", employee);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Departments = await GetDepartments();
            ViewBag.Roles = await GetRoles();
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Employee employee = null;
            HttpResponseMessage response = await client.GetAsync($"api/Employees/{id}");
            if (response.IsSuccessStatusCode)
            {
                employee = await response.Content.ReadAsAsync<Employee>();
            }
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Employees/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        private async Task<IEnumerable<SelectListItem>> GetDepartments()
        {
            IEnumerable<Department> departments = null;
            HttpResponseMessage response = await client.GetAsync("api/Departments");
            if (response.IsSuccessStatusCode)
            {
                departments = await response.Content.ReadAsAsync<IEnumerable<Department>>();
            }
            return departments.Select(d => new SelectListItem
            {
                Value = d.DepartmentId.ToString(),
                Text = d.DepartmentName
            });
        }

        private async Task<IEnumerable<SelectListItem>> GetRoles()
        {
            IEnumerable<Role> roles = null;
            HttpResponseMessage response = await client.GetAsync("api/Roles");
            if (response.IsSuccessStatusCode)
            {
                roles = await response.Content.ReadAsAsync<IEnumerable<Role>>();
            }
            return roles.Select(r => new SelectListItem
            {
                Value = r.RoleId.ToString(),
                Text = r.RoleName
            });
        }

        private ActionResult BadRequest()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}
