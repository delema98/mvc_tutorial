using Microsoft.AspNetCore.Mvc;
using mvc_tutorial.Data;
using mvc_tutorial.Models;

namespace mvc_tutorial.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable <Category> objCategoryList = _db.Categories;
            
            return View(objCategoryList);
        }
    }
}