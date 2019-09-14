using System;
using System.Collections.Generic;
using System.Text;

using CourseProject.Models;

namespace ShopGrabber
{
    class EFPutter : IPutter
    {
        private readonly Context context;

        public EFPutter(Context context)
        {
            this.context = context;
        }

        public void PutCustomers(List<Customer> customers)
        {
            context.Customers.AddRange(customers);
        }

        public void PutFabrics(List<Product> products)
        {
            foreach (var product in products)
                context.Fabrics.AddRange(product.Fabrics);
        }

        public void PutSizes(List<Product> products)
        {
            foreach (var product in products)
                context.Sizes.AddRange(product.Sizes);
        }

        public void PutProducts(List<Product> products)
        {
            context.Products.AddRange(products);
        }

        public void PutPurchaseProducts(List<PurchaseProduct> purchaseProducts)
        {
            context.PurchaseProducts.AddRange(purchaseProducts);
        }

        public void PutPurchases(List<Purchase> purchases)
        {
            context.Purchases.AddRange(purchases);
        }
    }
}
