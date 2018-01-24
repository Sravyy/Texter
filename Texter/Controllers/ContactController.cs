using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Texter.Models;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Texter.Controllers
{
	[Authorize]
    public class ContactController : Controller
    {
		// GET: /<controller>/
		private readonly ApplicationDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;

		public ContactController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
		{
			_userManager = userManager;
			_db = db;
		}

        public IActionResult Index()
        {   
            
            return View(_db.Contacts.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
			//var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			//var currentUser = await _userManager.FindByIdAsync(userId);
			//contact.User = currentUser;
            _db.Contacts.Add(contact);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
