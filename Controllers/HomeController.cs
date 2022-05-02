using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SneakEasy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace SneakEasy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }
        //LOGIN REGISTRATION

        //Registration
        [HttpGet("users/register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("users/create")]
        public IActionResult CreateUser(User newUser)
        {
            if(ModelState.IsValid)
            {
                //verify that email is not already registered:
                if(_context.Users.Any(s => s.Email == newUser.Email))
                {
                    //Means that the email is already in the database, so return an error message
                    ModelState.AddModelError("Email", "Email already registered");
                    return View("Register");
                }
                
                //hashing password:
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);

                _context.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                return RedirectToAction("Dashboard");
            } else {
                return View("Register");
            }
        }

        //Login

        [HttpGet("users/login")]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost("users/loggingIn")]
        public IActionResult LoggingIn(LoginUser loginUser)
        {
            if(ModelState.IsValid)
            {
                //find user based on email
                User userInDb = _context.Users.FirstOrDefault(d => d.Email == loginUser.LoginEmail);
                if(userInDb == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                    return View("Login");
                } 
                //check password against password given
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();

                var result = hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.LoginPassword);
            
                if(result == 0)
                {
                    //means password was incorrect
                    ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                    return View("Login");
                }
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("Dashboard");
            } else {
                return View("Login");
            }
        }

        //Dashboard

        [HttpGet("/")]
        public IActionResult Dashboard()
        {
            List<Sneaker> AllSneakers = new List<Sneaker>();
            AllSneakers = _context.Sneakers.Include(a => a.CustomerOrders).Include(a => a.Seller).OrderBy(a => a.Name).ToList();
            List<Sneaker> randSneakers = new List<Sneaker>(3);
            Random rand = new Random();
            randSneakers.Insert(0, AllSneakers[rand.Next(AllSneakers.Count())]);
            AllSneakers.Remove(randSneakers[0]);
            randSneakers.Insert(0, AllSneakers[rand.Next(AllSneakers.Count())]);
            AllSneakers.Remove(randSneakers[0]);
            randSneakers.Insert(0, AllSneakers[rand.Next(AllSneakers.Count())]);
            AllSneakers.Remove(randSneakers[0]);
            ViewBag.RandomSneakers = randSneakers;

            ViewBag.LoggedIn = _context.Users.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
            
            return View();
        }

        //Profile
        [HttpGet("users/profile")]
        public IActionResult UserProfile(int useId)
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login");
            }
            ViewBag.LoggedIn = _context.Users.Include(a => a.SneakersBeingSold).ThenInclude(a => a.CustomerOrders).FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
            ViewBag.AllSneakers = _context.Sneakers.Include(a => a.CustomerOrders).Include(a => a.Seller).OrderBy(a => a.Name).ToList();

            return View();
        }

        //Sell a pair of Sneakers

        [HttpGet("sneakers/add")]
        public IActionResult AddSneaker()
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login");
            }
            ViewBag.LoggedIn = _context.Users.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
            return View();
        }

        [HttpPost("sneakers/new")]
        public IActionResult NewSneaker(Sneaker newSneaker)
        {
            if(ModelState.IsValid)
            {
                newSneaker.UserId = (int)HttpContext.Session.GetInt32("UserId");
                _context.Sneakers.Add(newSneaker);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            } else {
                ViewBag.LoggedIn = _context.Users.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
                return View("AddSneaker");
            }
        }

        //All Shoes (Buy Shoes Page)


        [HttpGet("sneakers/all")]
        public IActionResult AllSneakers()
        {
            ViewBag.LoggedIn = _context.Users.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
            ViewBag.AllSneakers = _context.Sneakers.Include(a => a.CustomerOrders).OrderBy(a => a.Name).ToList();
            return View();
        }

        //View One Sneaker
        [HttpGet("sneaker/{sneakId}")]
        public IActionResult OneSneaker(int sneakId)
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login");
            }
            ViewBag.LoggedIn = _context.Users.Include(s=> s.SneakersBeingSold).Include(s => s.MyOrders).ThenInclude(s => s.Sneaker).OrderBy(a => a.CreatedAt).FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
            ViewBag.Sneaker = _context.Sneakers.Include(a => a.Seller).FirstOrDefault(a => a.SneakerId == sneakId);
            ViewBag.User = HttpContext.Session.GetInt32("UserId");
            return View();
        }

        //Buy sneakers route (create order)
        [HttpPost("sneaker/buy/{sneakId}")]
        public IActionResult BuySneaker(int sneakId)
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index");
            }
            Sneaker sneaker = _context.Sneakers.FirstOrDefault(a => a.SneakerId == sneakId);
            Order newOrder = new Order{UserId = (int)HttpContext.Session.GetInt32("UserId"), SneakerId = sneakId};
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return RedirectToAction("UserProfile");
        }

        //Edit Sneaker
        //Update Product
        [HttpGet("sneaker/edit/{sneakId}")]
        public IActionResult EditSneaker(int sneakId)
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Register");
            }
            Sneaker sneak = _context.Sneakers.FirstOrDefault(a => a.SneakerId == sneakId);
            return View(sneak);
        }

        [HttpPost("sneaker/update/{sneakId}")]
        public IActionResult UpdateProduct(int sneakId, Sneaker updatedVersion)
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Register");
            }
            Sneaker oldSneaker = _context.Sneakers.FirstOrDefault(a => a.SneakerId == sneakId);
            if(ModelState.IsValid)
            {
                oldSneaker.Name = updatedVersion.Name;
                oldSneaker.PhotoURL = updatedVersion.PhotoURL;
                oldSneaker.Price = updatedVersion.Price;
                oldSneaker.Size = updatedVersion.Size;
                oldSneaker.Brand = updatedVersion.Brand;
                oldSneaker.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return Redirect($"/sneaker/{sneakId}");
            } else {
                return View("EditSneaker", oldSneaker);
            }
        }

        //Delete Sneaker

        //DELETE product
        [HttpGet("sneaker/delete/{sneakId}")]
        public IActionResult DeleteProduct(int sneakId)
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Dashboard");
            }
            Sneaker SneakToDelete = _context.Sneakers.SingleOrDefault(a => a.SneakerId == sneakId);
            if(HttpContext.Session.GetInt32("UserId") != SneakToDelete.UserId)
            {
                return RedirectToAction("Dashboard");
            }
            _context.Sneakers.Remove(SneakToDelete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        //LOGOUT
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
