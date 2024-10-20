using GroupProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace GroupProject.Controllers
{
    public class HomeController : Controller
    {

        private ContactContext context { get; set; }

        public HomeController (ContactContext ctx)
        {
            context= ctx;
        }

        // Default action to display the home page
        public IActionResult Index()
        {
            var contacts = context.Contacts
                .Include(c => c.Category) 
                .OrderBy(c => c.LastName)
                .ToList();

            return View(contacts);
        }



    }
}
