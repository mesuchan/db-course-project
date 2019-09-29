﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;

using CourseProject.Models;

namespace ShopGrabber
{
    class HMGrabber : IGrabber
    {
        const string Url = "https://www2.hm.com/ru_ru/zhenshchiny/vybrat-kollekciyu/vechernyaya-odezhda.html?product-type=ladies_partywear&sort=stock&image-size=small&image=model&offset=0&page-size=100";
        const string ProductUrl = "https://www2.hm.com/ru_ru/productpage.%.html";

        Random R = new Random();
        List<string> Countries = new List<string>(5) { "Индия", "Китай", "Бангладеш", "Мьянма", "Вьетнам" };
        List<string> Fabrics = new List<string>(10) { "Хлопок", "Вискоза", "Полиэстр", "Эластан", "Акрил", "Шелк", "Лен", "Шерсть", "Нейлон", "Шифон"};
        List<string> Colors = new List<string>(6) { "Красный", "Желтый", "Зеленый", "Синий", "Черный", "Белый"};

        public List<Product> GrabProducts(int amount)
        {
            List<Product> products = new List<Product>(amount);

            List<string> indexes = GrabIndexes();

            for (int i = 0; i < amount; i++)
            {
                string url = ProductUrl.Replace("%", indexes[i]);
                var page = new HtmlWeb().Load(url);

                Product product = new Product();

                //product.ProductId = i + 1;

                var element = page.DocumentNode.SelectSingleNode("//h1[@class='primary product-item-headline']");
                product.Name = element.InnerHtml;

                element = page.DocumentNode.SelectSingleNode("//span[@class='price-value']");
                product.Price = Int32.Parse(FindNumbers(element.InnerText));

                //var elements = page.DocumentNode.SelectNodes("//div[contains(@class, 'product-colors')]//h3[@class='product-input-label']");
                product.Color = Colors[R.Next(0, 6)];

                product.Country = Countries[R.Next(0, 5)];

                element = page.DocumentNode.SelectSingleNode("//p[@class='pdp-description-text']");
                product.Description = element.InnerHtml;

                element = page.DocumentNode.SelectSingleNode("//div[@class='product-detail-main-image-container']//img");
                var pictureUrl = element.GetAttributeValue("src", "");
                var request = HttpWebRequest.Create("https:" + pictureUrl);
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                var reader = new BinaryReader(stream);
                product.Picture = reader.ReadBytes((int)response.ContentLength);

                product.Sizes = new List<ProductSize>();
                for (int j = 32; j <= 46; j += 2)
                {
                    ProductSize size = new ProductSize();
                    size.ProductId = i + 1;
                    size.Size = j;
                    size.Quantity = R.Next(0, 20);

                    product.Sizes.Add(size);
                }

                product.Fabrics = new List<ProductFabric>();
                int number = R.Next(1, 4);
                int f = R.Next(0, 8);
                for (int j = 1; j <= number; j++)
                {
                    ProductFabric fabric = new ProductFabric();
                    fabric.ProductId = i + 1;
                    fabric.Fabric = Fabrics[f];
                    f++;

                    if (j != number)
                        fabric.Procentage = 25;
                    else
                        fabric.Procentage = 100 - (number - 1) * 25;

                    product.Fabrics.Add(fabric);
                }

                products.Add(product);
            }

            return products;
        }

        private string FindNumbers(string innerText)
        {
            string str = "";

            foreach (var i in innerText)
            {
                if (Char.IsDigit(i))
                    str += i;
            }

            return str;
        }

        private List<string> GrabIndexes()
        {
            List<string> indexes = new List<string>();

            var page = new HtmlWeb().Load(Url);

            var links = page.DocumentNode.SelectNodes("//a[@class='item-link']");

            foreach (var link in links)
            {
                indexes.Add(link.Attributes["href"].Value.ToString().Substring(19, 10));
            }

            return indexes;
        }
    }
}
