using GroupProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GroupProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        // Action to list contacts
        public IActionResult Index()
        {
            _logger.LogInformation("Contact list accessed.");
            var contacts = new List<Contact>
            {
                new Contact { ContactID = 1, FirstName = "John", LastName = "Doe", Phone = "123-456-7890", Email = "john@example.com", Organization = "Company A", CategoryID = 1 },
                new Contact { ContactID = 2, FirstName = "Jane", LastName = "Smith", Phone = "987-654-3210", Email = "jane@example.com", Organization = "Company B", CategoryID = 2 }
            };
            return View(contacts);  // Return the view for listing contacts
        }

        // Action to view details of a specific contact
        public IActionResult Details(int id)
        {
            _logger.LogInformation($"Viewing details for contact with ID: {id}");
            var contact = new Contact
            {
                ContactID = id,
                FirstName = "John",
                LastName = "Doe",
                Phone = "123-456-7890",
                Email = "john@example.com",
                Organization = "Company A",
                CategoryID = 1
            };
            return View(contact);  // Return the view for displaying contact details
        }

        // Action to show the form for adding a new contact
        public IActionResult Add()
        {
            _logger.LogInformation("Add contact form accessed.");
            return View();  // Return the view with the form to add a new contact
        }

        // Action to handle form submission for adding a new contact
        [HttpPost]
public IActionResult Add(Contact model)
{
    if (ModelState.IsValid)
    {
        model.DateAdded = DateTime.Now;  // Set the current date and time when adding a contact
        _logger.LogInformation("New contact added.");
        // Logic to save the contact goes here
        return RedirectToAction("Index");
    }
    return View(model);  // Return to the form if validation fails
}

        // Action to show the form for editing an existing contact
        public IActionResult Edit(int id)
        {
            _logger.LogInformation($"Edit contact form accessed for contact with ID: {id}");
            var contact = new Contact
            {
                ContactID = id,
                FirstName = "John",
                LastName = "Doe",
                Phone = "123-456-7890",
                Email = "john@example.com",
                Organization = "Company A",
                CategoryID = 1
            };
            return View(contact);  // Return the view for editing contact
        }

        // Action to handle form submission for editing a contact
        [HttpPost]
        public IActionResult Edit(Contact model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation($"Contact with ID: {model.ContactID} updated.");
                // Logic to update contact goes here in the future
                return RedirectToAction("Index");  // Redirect back to the list of contacts
            }
            return View(model);  // Return to the form if model validation fails
        }

        // Action to confirm and delete a contact
        public IActionResult Delete(int id)
{
    var contact = new Contact
    {
        ContactID = id,
        FirstName = "John",
        LastName = "Doe",
        Phone = "123-456-7890",
        Email = "john@example.com",
        Organization = "Company A",
        CategoryID = 1
    };
    return View(contact);  // Pass a single Contact object to the view
}

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _logger.LogInformation($"Contact with ID: {id} deleted.");
            // Logic to delete contact goes here in the future
            return RedirectToAction("Index");  // Redirect back to the list of contacts
        }
    }
}
