using System;
using System.Collections.Generic;

namespace CourseProject.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int CustomerId { get; set; }

        public int Cost { get; set; }
        public int Discount { get; set; }
        public DateTime PurchaseTimer { get; set; }

        public List<PurchaseProduct> PurchaseProducts { get; set; }
        public Customer Customer { get; set; }
    }
}
