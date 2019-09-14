﻿using System;
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
                int l = R.Next(0, 5);
                for (int j = 0; j < l; j++)
                {
                    PurchaseProduct purchaseProduct = new PurchaseProduct();
                    purchaseProduct.PurchaseId = i + 1;
                    purchaseProduct.ProductId = R.Next(1, 101);

                    purchaseProducts.Add(purchaseProduct);
                }
            }

            return purchaseProducts;
        }
    }
}
