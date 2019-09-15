using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CourseProject.Models;

namespace ShopGrabber
{
    class GeneratePurchaseProduct:IPurchaseProductGenerator
    {
        Random R = new Random();

        public List<PurchaseProduct> GeneratePurchaseProducts(int amount)
        {
            List<PurchaseProduct> purchaseProducts = new List<PurchaseProduct>();

            for (int i = 0; i < amount; i++)
            {
                int l = R.Next(0, 3);
                for (int j = 0; j < l; j++)
                {
                    PurchaseProduct purchaseProduct = new PurchaseProduct();

                    purchaseProduct.PurchaseId = i + 1;

                    if (i == 0)
                        purchaseProduct.ProductId = R.Next(0, 31);
                    if (i == 1)
                        purchaseProduct.ProductId = R.Next(31, 61);
                    if (i == 2)
                        purchaseProduct.ProductId = R.Next(61, 101);

                    purchaseProducts.Add(purchaseProduct);
                }
            }

            return purchaseProducts;
        }
    }
}
