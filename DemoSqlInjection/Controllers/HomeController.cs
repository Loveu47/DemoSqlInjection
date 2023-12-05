using DemoSqlInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DemoSqlInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db = new AppDbContext();
        private Users userNull = new Users() {
            FirstName = ""        
        };
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(userNull);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username,string password)
        {   

            var sql = $"SELECT * FROM users WHERE username = '{username}' AND password = '{password}'";

            List<Users> users =  _db.Users.FromSqlRaw(sql).ToList();
            if (users.Count() == 0)
            {
                ViewBag.Messager = "Thông tin tài khoản hoặc mật khẩu không chính xác!!!";
                return View("Login");
            }
            return View("Index", users[0]);
        }
        
        public IActionResult About(int id)
        {
            var sql = $"SELECT * FROM users WHERE userid = '{id}'";
            Users user = _db.Users.FromSqlRaw(sql).First();
            if (user == null) { return NotFound(); }
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}