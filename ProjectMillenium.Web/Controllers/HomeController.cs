using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectMillenium.Core.Helpers;
using ProjectMillenium.Web.Models;
using System.Diagnostics;

namespace ProjectMillenium.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPasswordHasher _passwordHasher;

        public HomeController(ILogger<HomeController> logger, IPasswordHasher passwordHasher)
        {
            _logger = logger;
            _passwordHasher = passwordHasher;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Bu bir bilgilendirmedir.");
            _logger.LogError("Hata");

            return View();
        }

        [HttpGet]
        public IActionResult GetHash()
        {
            
            string password = "your_password";
            byte[] salt;
            string hashedPassword = _passwordHasher.HashPassword(password, out salt);

  
            return View();
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Bu bir log mesajıdır.");
            return View();
        }

        public IActionResult Privacy()
        {
            throw new Exception("Test");
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() 
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
