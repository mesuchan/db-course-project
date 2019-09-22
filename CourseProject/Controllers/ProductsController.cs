using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseProject.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly Context context;
        private readonly UserManager<IdentityUser> userManager;

        public ProductsController(Context context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return context.Products.Select(p => p);
        }

        // GET: api/<controller>
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = context.Products.Select(p => p).Include(p => p.Sizes).Where(p => p.ProductId == id).FirstOrDefault();
            if (product == null)
                return NotFound();
            return product;
        }

        [Authorize]
        [HttpPost("purchase")]
        public async Task<ActionResult> PurchaseAsync([FromBody] Purchase value)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var customer = await Customer.GetOrCreateAsync(context, user);
            var purchase = new Purchase
            {
                Customer = customer
            };
            context.Add(purchase);
            await context.SaveChangesAsync();
            foreach (var pp in value.PurchaseProducts)
            {
                pp.PurchaseId = purchase.PurchaseId;

                var size = context.Sizes.Find(new { pp.ProductId, pp.Size });
                size.Quantity--;
                context.Update(size);
            }
            context.AddRange(value.PurchaseProducts);
            await context.SaveChangesAsync();
            return Ok(purchase);
        }
    }
}
