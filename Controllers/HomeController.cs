using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("uuid") != null)
            {
                return RedirectToAction("WeddingList");
            }
            return View();
        }

        [HttpPost("/createuser")]
        public IActionResult CreateUser(User NewUser)
        {
            if (ModelState.IsValid)
            {
                // If a User exists with provided email
                if (_context.Users.Any(u => u.Email == NewUser.Email))
                {
                    // Manually add a ModelState error to the Email field, with provided
                    // error message
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
                _context.Users.Add(NewUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("uuid", NewUser.UserId);
                return RedirectToAction("WeddingList");
            }
            return View("Index");
        }

        [HttpGet("/login/form")]
        public IActionResult LoginForm()
        {
            return View();
        }

        [HttpPost("/login/submit")]
        public IActionResult LoginAction(LoginUser userSubmission)
        {
            if (ModelState.IsValid)
            {
                // If inital ModelState is valid, query for a user with provided email
                var userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.LoginEmail);
                // If no user exists with provided email
                if (userInDb == null)
                {
                    // Add an error to ModelState and return to View!
                    ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                    return View("LoginForm");
                }

                // Initialize hasher object
                var hasher = new PasswordHasher<LoginUser>();

                // verify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LoginPassword);

                // result can be compared to 0 for failure
                if (result == 0)
                {
                    // handle failure (this should be similar to how "existing email" is handled)
                    ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                    return View("LoginForm");
                }
                HttpContext.Session.SetInt32("uuid", userInDb.UserId);
                return RedirectToAction("WeddingList");
            }
            return View("LoginForm");
        }

        [HttpGet("/WeddingList")]
        public IActionResult WeddingList()
        {
            if (HttpContext.Session.GetInt32("uuid") == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.CurrentUser = _context.Users.FirstOrDefault(user => user.UserId == HttpContext.Session.GetInt32("uuid"));

            ViewBag.AllWeddings = _context.Weddings.Include(Wedding => Wedding.Guests);
            return View();
        }

        [HttpGet("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet("/weddings/new")]
        public IActionResult WeddingForm()
        {
            if (HttpContext.Session.GetInt32("uuid") == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.UUID = HttpContext.Session.GetInt32("uuid");
            return View();
        }

        [HttpPost("/weddings/new/submit")]
        public IActionResult CreateWedding(Wedding NewWedding)
        {
            if (HttpContext.Session.GetInt32("uuid") == null)
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                _context.Weddings.Add(NewWedding);
                _context.SaveChanges();
                return RedirectToAction("WeddingList");
            }
            ViewBag.UUID = HttpContext.Session.GetInt32("uuid");
            return View("WeddingForm");
        }

        [HttpGet("/wedding/{id}/rsvp")]
        public IActionResult RSVPWedding(int id)
        {
            if (HttpContext.Session.GetInt32("uuid") == null)
            {
                return RedirectToAction("Index");
            }
            WeddingGuest Guest = new WeddingGuest();
            Guest.GuestId = HttpContext.Session.GetInt32("uuid").GetValueOrDefault();
            Guest.WeddingId = id;
            _context.WeddingGuests.Add(Guest);
            _context.SaveChanges();

            return RedirectToAction("WeddingList");
        }
        [HttpGet("/wedding/{id}/rsvp/remove")]
        public IActionResult RemoveRSVPWedding(int id)
        {
            if (HttpContext.Session.GetInt32("uuid") == null)
            {
                return RedirectToAction("Index");
            }
            WeddingGuest GuestToRemove = _context.WeddingGuests.FirstOrDefault(guest => guest.GuestId == HttpContext.Session.GetInt32("uuid").GetValueOrDefault() && guest.WeddingId == id);
            _context.WeddingGuests.Remove(GuestToRemove);
            _context.SaveChanges();

            return RedirectToAction("WeddingList");
        }

        [HttpGet("/wedding/{id}")]
        public IActionResult WeddingDetails (int id)
        {
            if (HttpContext.Session.GetInt32("uuid") == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Wedding = _context.Weddings
                .Include(wedding => wedding.Guests)
                    .ThenInclude(guests => guests.Guest)
                .FirstOrDefault(wedding => wedding.WeddingId == id);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
