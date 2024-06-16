using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace New_WebApllication.Models
{
    public class PerformanceReview
    {
        public int ReviewId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ReviewText { get; set; }
    }
}