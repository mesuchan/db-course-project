using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CourseProject.Models;

namespace ShopGrabber
{
    public interface IPutter
    {
        void PutProducts(List<Product> products);
        void PutSizes(List<Product> products);
        void PutFabrics(List<Product> products);
        void PutCustomers(List<Customer> customers);
        void PutPurchases(List<Purchase> purchases);
        void PutPurchaseProducts(List<PurchaseProduct> purchaseProducts);
    }
}
