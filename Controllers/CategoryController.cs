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
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "DisplayOrder and Name can't be the same");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            // id is sufficient, bc find looks for primary key which is id
            var categoryFromDb = _db.Categories.Find(id);

            // Alternatives need lambda, bc they look through the whole elements
            // var categoryFromDbFirst  = _db.Categories.FirstOrDefault(u=>u.Id==id);
            // var categoryFromDbSingle  = _db.Categories.SingleOrDefault(u=>u.Id==id);
            
            if (categoryFromDb  == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "DisplayOrder and Name can't be the same");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET
        public IActionResult Delete(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            // id is sufficient, bc find looks for primary key which is id
            var categoryFromDb = _db.Categories.Find(id);

            // Alternatives need lambda, bc they look through the whole elements
            // var categoryFromDbFirst  = _db.Categories.FirstOrDefault(u=>u.Id==id);
            // var categoryFromDbSingle  = _db.Categories.SingleOrDefault(u=>u.Id==id);
            
            if (categoryFromDb  == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}