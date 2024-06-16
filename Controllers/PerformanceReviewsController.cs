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
    public class PerformanceReviewsController : ApiController
    {
        private HRMSContext db = new HRMSContext();

        // GET: api/PerformanceReviews
        [HttpGet]
        public IEnumerable<PerformanceReview> GetPerformanceReviews()
        {
            return db.GetPerformanceReviews();
        }

        // GET: api/PerformanceReviews/5
        [HttpGet]
        public IHttpActionResult GetPerformanceReview(int id)
        {
            var review = db.GetPerformanceReviewById(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        // POST: api/PerformanceReviews
        [HttpPost]
        public IHttpActionResult PostPerformanceReview(PerformanceReview review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.AddPerformanceReview(review);
            return CreatedAtRoute("DefaultApi", new { id = review.ReviewId }, review);
        }

        // PUT: api/PerformanceReviews/5
        [HttpPut]
        public IHttpActionResult PutPerformanceReview(int id, PerformanceReview review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != review.ReviewId)
            {
                return BadRequest();
            }
            db.UpdatePerformanceReview(review);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/PerformanceReviews/5
        [HttpDelete]
        public IHttpActionResult DeletePerformanceReview(int id)
        {
            var review = db.GetPerformanceReviewById(id);
            if (review == null)
            {
                return NotFound();
            }
            db.DeletePerformanceReview(id);
            return Ok(review);
        }
    }
}

