using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CourseProject.Models;

namespace ShopGrabber
{
    interface ICustomerGenerator
    {
        List<Customer> GenerateCustomers(int amount);
    }
}
