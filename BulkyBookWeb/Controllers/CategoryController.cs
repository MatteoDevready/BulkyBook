using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db= db;
        }

        public IActionResult Index()
        {
            //IEnumeramble supports iteration accross collections so the ToList method at the end is not necessary
            //IEnumerable<Category> objCategoryList = _db.Categories.ToList();
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
        //Its is prevent to avoid Forgery attacks, it will generate a key thatw ill be validated at this step
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj) 
        {
            //checking that the two filed are not represented with the same value
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.TryAddModelError("Name","The DisplayOrder cannot match the Name");
            }

            //determine if the model is valid or not
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
            
        }
    }
}
