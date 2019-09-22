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
    [Authorize]
    [Route("api/user")]
    public class ProfileController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private Context context;

        public ProfileController(UserManager<IdentityUser> userManager, Context context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<Customer> Get()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var customer = await Customer.GetOrCreateAsync(context, user);

            return customer;
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task Put([FromBody]Customer value)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var customer = await Customer.GetOrCreateAsync(context, user);
            context.Update(customer);

            customer.FirstName = value.FirstName;
            customer.LastName = value.LastName;
            customer.PhoneNumber = value.PhoneNumber;
            customer.Mail = value.Mail;

            await context.SaveChangesAsync();
        }
    }
}
