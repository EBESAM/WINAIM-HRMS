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
    public class PerformanceReviewController : Controller
    {
        private readonly HttpClient client;

        public PerformanceReviewController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44376/"); // Change to your API base address
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: PerformanceReview
        public async Task<ActionResult> Index()
        {
            IEnumerable<PerformanceReview> reviews = null;
            HttpResponseMessage response = await client.GetAsync("api/PerformanceReviews");
            if (response.IsSuccessStatusCode)
            {
                reviews = await response.Content.ReadAsAsync<IEnumerable<PerformanceReview>>();
            }
            else
            {
                reviews = Enumerable.Empty<PerformanceReview>();
                ModelState.AddModelError(string.Empty, "Server error while retrieving performance reviews.");
            }
            return View(reviews);
        }

        // GET: PerformanceReview/Details/5
        public async Task<ActionResult> Details(int id)
        {
            PerformanceReview review = null;
            HttpResponseMessage response = await client.GetAsync($"api/PerformanceReviews/{id}");
            if (response.IsSuccessStatusCode)
            {
                review = await response.Content.ReadAsAsync<PerformanceReview>();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error while retrieving performance review details.");
            }
            return View(review);
        }

        // GET: PerformanceReview/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Employees = await GetEmployees();
            return View();
        }

        // POST: PerformanceReview/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PerformanceReview review)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/PerformanceReviews", review);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error while creating performance review.");
                }
            }
            ViewBag.Employees = await GetEmployees();
            return View(review);
        }

        // GET: PerformanceReview/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            PerformanceReview review = null;
            HttpResponseMessage response = await client.GetAsync($"api/PerformanceReviews/{id}");
            if (response.IsSuccessStatusCode)
            {
                review = await response.Content.ReadAsAsync<PerformanceReview>();
                ViewBag.Employees = await GetEmployees();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error while retrieving performance review details.");
            }
            return View(review);
        }

        // POST: PerformanceReview/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PerformanceReview review)
        {
            if (id != review.ReviewId)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"api/PerformanceReviews/{id}", review);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error while updating performance review.");
                }
            }
            ViewBag.Employees = await GetEmployees();
            return View(review);
        }

        // GET: PerformanceReview/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            PerformanceReview review = null;
            HttpResponseMessage response = await client.GetAsync($"api/PerformanceReviews/{id}");
            if (response.IsSuccessStatusCode)
            {
                review = await response.Content.ReadAsAsync<PerformanceReview>();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error while retrieving performance review details.");
            }
            return View(review);
        }

        // POST: PerformanceReview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/PerformanceReviews/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error while deleting performance review.");
            }
            return RedirectToAction("Index");
        }

        private async Task<IEnumerable<SelectListItem>> GetEmployees()
        {
            IEnumerable<Employee> employees = null;
            HttpResponseMessage response = await client.GetAsync("api/Employees");
            if (response.IsSuccessStatusCode)
            {
                employees = await response.Content.ReadAsAsync<IEnumerable<Employee>>();
            }
            return employees?.Select(e => new SelectListItem
            {
                Value = e.EmployeeId.ToString(),
                Text = $"{e.FirstName} {e.LastName}"
            });
        }
    }
}
