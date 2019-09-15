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
            context.SaveChanges();
        }

        public void PutFabrics(List<Product> products)
        {
            foreach (var product in products)
                context.Fabrics.AddRange(product.Fabrics);
            context.SaveChanges();
        }

        public void PutSizes(List<Product> products)
        {
            foreach (var product in products)
                context.Sizes.AddRange(product.Sizes);
            context.SaveChanges();
        }

        public void PutProducts(List<Product> products)
        {
            context.Products.AddRange(products);
            context.SaveChanges();
        }

        public void PutPurchaseProducts(List<PurchaseProduct> purchaseProducts)
        {
            context.PurchaseProducts.AddRange(purchaseProducts);
            context.SaveChanges();
        }

        public void PutPurchases(List<Purchase> purchases)
        {
            context.Purchases.AddRange(purchases);
            context.SaveChanges();
        }
    }
}
