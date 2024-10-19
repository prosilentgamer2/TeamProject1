using GroupProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace GroupProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly ContactContext _context;  // Add this to use _context

        public ContactController(ILogger<ContactController> logger, ContactContext context)
        {
            _logger = logger;
            _context = context;  // Initialize _context
        }

        // Action to list contacts (Simulated data)
        public IActionResult SimulatedIndex()
        {
            _logger.LogInformation("Contact list accessed (Simulated data).");

            // Simulating data with Categories included
            var contacts = new List<Contact>
            {
                new Contact
                {
                    ContactID = 1, FirstName = "John", LastName = "Doe",
                    Phone = "123-456-7890", Email = "john@example.com",
                    Organization = "Company A", CategoryID = 1,
                    Category = new Category { Name = "Friends" }
                },
                new Contact
                {
                    ContactID = 2, FirstName = "Jane", LastName = "Smith",
                    Phone = "987-654-3210", Email = "jane@example.com",
                    Organization = "Company B", CategoryID = 2,
                    Category = new Category { Name = "Colleagues" }
                }
            };

            return View("Index", contacts);  // Return the view for listing contacts
        }

        // Action to list contacts from the database (use _context)
        public IActionResult Index()
        {
            _logger.LogInformation("Contact list accessed from the database.");

            var contacts = _context.Contacts
                .Include(c => c.Category)  // Include category if necessary
                .OrderBy(c => c.LastName)
                .ToList();  // Fetch contacts from the database

            if (contacts == null || contacts.Count == 0)
            {
                return NotFound("No contacts found.");
            }

            return View(contacts);  // Pass the list of contacts to the view
        }

        // Other actions (Add, Edit, Delete) remain unchanged

        public IActionResult Add()
        {
            _logger.LogInformation("Add contact form accessed.");
            return View();  // Return the view with the form to add a new contact
        }

        [HttpPost]
        public IActionResult Add(Contact model)
        {
            if (ModelState.IsValid)
            {
                model.DateAdded = DateTime.Now;  // Set the current date and time when adding a contact
                _logger.LogInformation("New contact added.");
                _context.Contacts.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            _logger.LogWarning("Failed to add contact. Model state is invalid.");
            return View(model);  // Return to the form if validation fails
        }

        public IActionResult Edit(int id)
        {
            _logger.LogInformation($"Edit contact form accessed for contact with ID: {id}");

            var contact = _context.Contacts
                .Include(c => c.Category)
                .FirstOrDefault(c => c.ContactID == id);  // Fetch contact from database

            if (contact == null)
            {
                return NotFound("Contact not found.");
            }

            return View(contact);  // Return the view for editing contact
        }

        [HttpPost]
        public IActionResult Edit(Contact model)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Update(model);
                _context.SaveChanges();
                _logger.LogInformation($"Contact with ID: {model.ContactID} updated.");
                return RedirectToAction("Index");
            }

            _logger.LogWarning($"Failed to update contact with ID: {model.ContactID}. Model state is invalid.");
            return View(model);  // Return to the form if model validation fails
        }

        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"Delete contact form accessed for contact with ID: {id}");

            var contact = _context.Contacts
                .Include(c => c.Category)
                .FirstOrDefault(c => c.ContactID == id);  // Fetch contact from database

            if (contact == null)
            {
                return NotFound("Contact not found.");
            }

            return View(contact);  // Pass a single Contact object to the view
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
                _logger.LogInformation($"Contact with ID: {id} deleted.");
            }

            return RedirectToAction("Index");  // Redirect back to the list of contacts
        }
    }
}
