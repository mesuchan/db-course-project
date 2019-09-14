using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int CustomerId { get; set; }

        public int Cost { get; set; }
        public int Discount { get; set; }
        public DateTime PurchaseTimer { get; set; }
    }
}
