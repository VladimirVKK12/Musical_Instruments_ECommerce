using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Musical_Instruments_ECommerce.DbConnection;
using Musical_Instruments_ECommerce.Models;
using Musical_Instruments_ECommerce.ViewModel.InstrumentsVM;
using System.Diagnostics.Metrics;

namespace Musical_Instruments_ECommerce.Controllers
{
    public class InstrumentsController : Controller
    {
        public readonly AppDbContext db;

        public InstrumentsController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var instruments = db.Instruments.ToList();
            return View(instruments);
        }

        private string UploadImage(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                return null;

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                 imageFile.CopyToAsync(fileStream);
            }

            return "/images/" + fileName; 
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(InstrumentsCRUD model,IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.ImagePath = UploadImage(image);
            var instrument = new Instruments
            {
                Id = model.Id,  
                Name = model.Name,
                Type = model.Type,
                Price = model.Price,
                Description = model.Description,
                ImagePath = model.ImagePath
            };
            db.Instruments.Add(instrument);
            return RedirectToAction("InstrumentsTable");
        }
    }
}
