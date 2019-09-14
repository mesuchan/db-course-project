using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Viewed
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public int Count { get; set; }
    }
}
