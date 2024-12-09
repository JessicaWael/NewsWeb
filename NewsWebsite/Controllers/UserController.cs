using Microsoft.AspNetCore.Mvc;
using NewsWebsite.Models;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;

namespace NewsWebsite.Controllers
{
    public class UserController : Controller
    {
        private readonly NewsDBcontext _dbContext;

        public UserController(NewsDBcontext dbContext)
        {
            _dbContext = dbContext;
        }

        /* public async Task<IActionResult> Index()
         {
             var items = await _dbContext.Items.ToListAsync();
             return View(items);
         }*/
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        
        public IActionResult Register(string username, string password, string email)
        {
            if (_dbContext.users.Any(u => u.Username == username))
            {
                // Username already exists
                ModelState.AddModelError(string.Empty, "Username already exists. Please choose a different one.");
                return View();
            }

            // Hash the password
            string hashedPassword = HashPassword(password);

            // Add the new user to the database
            _dbContext.users.Add(new users { Username = username, Password = hashedPassword, Email = email });
            _dbContext.SaveChanges();

            // Registration successful
            return RedirectToAction("Index", "Home"); // Redirect to home page
        }

        // Method to hash password
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            var user = _dbContext.users.FirstOrDefault(u => u.Username == username);
            if (user != null && ValidatePassword(password, user.Password))
            {
                // Login successful
                return RedirectToAction("Index", "Home"); // Redirect to home page
            }
            else
            {
                // Invalid credentials
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return View();
            }
        }
        private bool ValidatePassword(string inputPassword, string hashedPassword)
        {
            string hashedInputPassword = HashPassword(inputPassword);
            return hashedInputPassword == hashedPassword;
        }
        /* public IActionResult Logout()
         {
             HttpContext.Session.Clear();
             return RedirectToAction("Index", "Home");
         }*/
      /*  static string HashedPassword(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);

            byte[] HashedPasswordbyte = new MD5CryptoServiceProvider().ComputeHash(bytes);

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < HashedPasswordbyte.Length; i++)
            {
                stringBuilder.Append(HashedPasswordbyte[i].ToString("x2"));
            }

            //string HashPassword = Encoding.UTF8.GetString(HashedPasswordbyte);

            return stringBuilder.ToString();
        }*/

    }
}
