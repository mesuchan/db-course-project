using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CourseProject.Models;

namespace ShopGrabber
{
    class GeneratePurchaseRandom : IPurchaseGenerator
    {
        Random R = new Random();

        public List<Purchase> GeneratePurchase(int amount)
        {
            List<Purchase> purchases = new List<Purchase>();

            for (int i = 0; i < amount; i++)
            {
                Purchase purchase = new Purchase();

                purchase.PurchaseId = i + 1;
                purchase.CustomerId = R.Next(1, 101);

                purchase.Cost = R.Next(1000, 10000);

                purchase.Discount = R.Next(0, 11);

                purchase.PurchaseTimer = new DateTime(2018, 01, 01); 

                purchases.Add(purchase);
            }

            return purchases;
        }
    }
}
