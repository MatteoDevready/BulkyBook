using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

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
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }


        //Nullable types are instances of the System.Nullable struct. 
        //A nullable type can represent the correct range of values for its underlying value type, plus an additional null value.
        //For example, a Nullable<Int32>, pronounced "Nullable of Int32," can be assigned any value from -2147483648 to 2147483647, 
        //or it can be assigned the null value.A Nullable<bool> can be assigned the values true, false, or null. 
        //The ability to assign null to numeric and Boolean types is especially useful when you are dealing with databases 
        //and other data types that contain elements that may not be assigned a value.
        //For example, a Boolean field in a database can store the values true or false, or it may be undefined.

        //GET
        public IActionResult Edit(int? id)
        {
            if (id ==null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);
            //other ways to retrieve the category id from the db
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);


            if (categoryFromDb == null) 
            {
                return NotFound();
            }
            else
            {
                return View(categoryFromDb);
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.TryAddModelError("Name","The DisplayOrder cannot match the Name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
            
        }
        
        //GET
        public IActionResult Delete(int? id)
        {
            if (id ==null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);


            if (categoryFromDb == null) 
            {
                return NotFound();
            }
            else
            {
                return View(categoryFromDb);
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index");
            
        }
    }
}
