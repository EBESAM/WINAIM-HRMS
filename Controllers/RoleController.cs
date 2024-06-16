using New_WebApllication.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace New_WebApllication.Controllers
{
    public class RoleController : Controller
    {
        private readonly HttpClient client;

        public RoleController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44376/"); // Change to your API base address
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Role
        public async Task<ActionResult> Index()
        {
            IEnumerable<Role> roles = null;
            HttpResponseMessage response = await client.GetAsync("api/Roles");
            if (response.IsSuccessStatusCode)
            {
                roles = await response.Content.ReadAsAsync<IEnumerable<Role>>();
            }
            return View(roles);
        }

        // GET: Role/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Role role = null;
            HttpResponseMessage response = await client.GetAsync($"api/Roles/{id}");
            if (response.IsSuccessStatusCode)
            {
                role = await response.Content.ReadAsAsync<Role>();
            }
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Role role)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Roles", role);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(role);
        }

        // GET: Role/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Role role = null;
            HttpResponseMessage response = await client.GetAsync($"api/Roles/{id}");
            if (response.IsSuccessStatusCode)
            {
                role = await response.Content.ReadAsAsync<Role>();
            }
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Role/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Role role)
        {
           
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"api/Roles/{id}", role);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(role);
        }

        // GET: Role/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Role role = null;
            HttpResponseMessage response = await client.GetAsync($"api/Roles/{id}");
            if (response.IsSuccessStatusCode)
            {
                role = await response.Content.ReadAsAsync<Role>();
            }
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Roles/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
