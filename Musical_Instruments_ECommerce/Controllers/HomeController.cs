using Microsoft.AspNetCore.Mvc;
using Musical_Instruments_ECommerce.DbConnection;
using Musical_Instruments_ECommerce.Models;
using System.Diagnostics;

namespace Musical_Instruments_ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext db;
        public HomeController(ILogger<HomeController> logger,AppDbContext _db)
        {
            db = _db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var instrumentsList = db.Instruments.ToList();
            return View(instrumentsList);
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
