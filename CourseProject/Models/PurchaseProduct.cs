using Newtonsoft.Json;

namespace CourseProject.Models
{
    public class PurchaseProduct
    {
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public int Size { get; set; }

        [JsonIgnore]
        public Purchase Purchase { get; set; }
        public Product Product { get; set; }
    }
}
