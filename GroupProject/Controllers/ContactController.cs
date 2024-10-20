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
        private ContactContext context { get; set; }

        public ContactController(ContactContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            return View("Edit", new Contact());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var contact = context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            var contact = context.Contacts.Find(id);
            return View(contact);

        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactID == 0)
                {
                    context.Contacts.Add(contact);
                }
                else
                {
                    context.Contacts.Update(contact);
                }

                context.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Action = (contact.ContactID == 0) ? "Add" : "Edit";
                ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
                return View(contact);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = context.Contacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
