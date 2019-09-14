using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CourseProject.Models;

namespace ShopGrabber
{
    public interface IGrabber
    {
        List<Product> GrabProducts(int amount);
    }
}
