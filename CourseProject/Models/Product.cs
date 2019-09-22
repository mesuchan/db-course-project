using System.Collections.Generic;

namespace CourseProject.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string Country { get; set; }
        public byte[] Picture { get; set; }
        public string Description { get; set; }

        public List<ProductSize> Sizes { get; set; }
        public List<ProductFabric> Fabrics { get; set; }
    }
}
