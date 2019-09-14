using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CourseProject.Models;

namespace ShopGrabber
{
    class GenerateCustomerRandom : ICustomerGenerator
    {
        Random R = new Random();

        List<string> FemaleFirstNames = new List<string>(10) { "Мария", "Александра", "Людмила", "Анна", "Дарья", "Елена", "Алиса", "Юлия", "Анастасия", "Елизавета" };
        List<string> FemaleLastNames = new List<string>(10) { "Зубарева", "Грошихина", "Калина", "Юрченко", "Шибанова", "Иванова", "Семина", "Шинина", "Круглова", "Девова" };

        List<string> MaleFirstNames = new List<string>(10) { "Даниил", "Никита", "Алексей", "Артем", "Ян", "Александр", "Михаил", "Юрий", "Андрей", "Павел" };
        List<string> MaleLastNames = new List<string>(10) { "Жуков", "Иксарица", "Кириллов", "Барабаш", "Бирбровер", "Замский", "Васин", "Волков", "Щусев", "Рудь" };

        string MailSigns = "abcdefghjklmnopqrstuvwxyz1234567890._-";
        List<string> MailAdresses = new List<string>(5) { "@gmail.com", "@mail.ru", "@yandex.ru", "@outlook.com", "@rambler.com" };

        public List<Customer> GenerateCustomers(int amount)
        {
            List<Customer> customers = new List<Customer>();

            for (int i = 0; i < amount; i++)
            {
                Customer customer = new Customer();

                customer.CustomerId = i + 1;

                if (R.Next(0, 2) == 0)
                {
                    customer.FirstName = FemaleFirstNames[R.Next(0, 10)];
                    customer.LastName = FemaleLastNames[R.Next(0, 10)];
                }
                else
                {
                    customer.FirstName = MaleFirstNames[R.Next(0, 10)];
                    customer.LastName = MaleLastNames[R.Next(0, 10)];
                }

                customer.PhoneNumber = "+";
                for (int j = 0; j < 10; j++)
                {
                    customer.PhoneNumber += R.Next(0, 10).ToString();
                }

                customer.Mail = "";
                int l = R.Next(5, 11);
                for (int j = 0; j < l; j++)
                {
                    customer.Mail += MailSigns[R.Next(0, 38)];
                }
                customer.Mail += MailAdresses[R.Next(0, 5)];

                customer.Discount = R.Next(0, 11);

                customer.RegisterDate = new DateTime(R.Next(2000, 2019), R.Next(1, 13), R.Next(1, 29));

                customers.Add(customer);
            }

            return customers;
        }
    }
}
