using New_WebApllication.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;



namespace New_WebApllication.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly HttpClient client;

        public DepartmentController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44376/"); // Change to your API base address
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Department
        public async Task<ActionResult> Index()
        {
            IEnumerable<Department> departments = null;
            HttpResponseMessage response = await client.GetAsync("api/Departments");
            if (response.IsSuccessStatusCode)
            {
                departments = await response.Content.ReadAsAsync<IEnumerable<Department>>();
            }
            return View(departments);
        }

        // GET: Department/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Department department = null;
            HttpResponseMessage response = await client.GetAsync($"api/Departments/{id}");
            if (response.IsSuccessStatusCode)
            {
                department = await response.Content.ReadAsAsync<Department>();
            }
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Departments", department);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(department);
        }

        // GET: Department/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Department department = null;
            HttpResponseMessage response = await client.GetAsync($"api/Departments/{id}");
            if (response.IsSuccessStatusCode)
            {
                department = await response.Content.ReadAsAsync<Department>();
            }
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Department department)
        {
           
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"api/Departments/{id}", department);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(department);
        }

        // GET: Department/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Department department = null;
            HttpResponseMessage response = await client.GetAsync($"api/Departments/{id}");
            if (response.IsSuccessStatusCode)
            {
                department = await response.Content.ReadAsAsync<Department>();
            }
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Departments/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
