using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroupProject.Models;  // Adjust the namespace to match your project

namespace GroupProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContactContext _context;

        public HomeController(ContactContext ctx)
        {
            _context = ctx;
        }

        // Index action that returns a list of contacts
        public IActionResult Index()
        {
            // Fetch contacts from the database, including related Category
            var contacts = _context.Contacts
                .Include(c => c.Category)  // Include the Category object
                .OrderBy(c => c.LastName)  // Order by last name
                .ToList();

            return View(contacts);  // Pass the contacts list to the view
        }
    }
}
