using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public IdentityUser IdentityUser { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public int Discount { get; set; }
        public DateTime RegisterDate { get; set; }

        public static async Task<Customer> GetOrCreateAsync(Context context, IdentityUser user)
        {
            var customer = context.Customers.Select(c => c)
                .Include(c => c.IdentityUser)
                .Where(c => c.IdentityUser == user)
                .FirstOrDefault();
            if (customer == null)
            {
                customer = new Customer
                {
                    IdentityUser = user
                };
                context.Add(customer);
                await context.SaveChangesAsync();
            }
            return customer;
        }
    }
}
