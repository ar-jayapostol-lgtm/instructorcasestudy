using Microsoft.AspNetCore.Mvc;
using Instrutorcasestudy.Data;
using Instrutorcasestudy.Models;
using Instrutorcasestudy.ViewModels;

namespace Instrutorcasestudy.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserAccount
                {
                    AdminID = model.AdminID,
                    Age = model.Age,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    Address = model.Address,
                    Username = model.Username,
                    Password = model.Password
                };

                _context.UserAccounts.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.UserAccounts
                    .FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

                if (user != null)
                {
                    return RedirectToAction("Dashboard");
                }

                ModelState.AddModelError("", "Invalid Username or Password");
            }
            return View(model);
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}