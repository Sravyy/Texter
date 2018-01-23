using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Texter.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Texter.Controllers
{
    public class ContactController : Controller
    {
        // GET: /<controller>/
        private TexterDbContext db = new TexterDbContext();
        public IActionResult Index()
        {   
            
            return View(db.Contacts.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
