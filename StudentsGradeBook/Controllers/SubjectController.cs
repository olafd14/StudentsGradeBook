using Microsoft.AspNetCore.Mvc;
using StudentsGradeBook.Data;
using StudentsGradeBook.Models;

namespace StudentsGradeBook.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SubjectController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Subject> objCategoryList = _db.Subjects.ToList();
            return View(objCategoryList);
        }

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Subject obj)
        {
            var existingCategory = _db.Subjects.FirstOrDefault(c => c.SubjectName == obj.SubjectName);

            if (existingCategory != null)
            {
                ModelState.AddModelError("Name", "A category with the same name already exists.");
            }

           
            if (ModelState.IsValid)
            {
                _db.Subjects.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion

        #region Edit

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Subject category = _db.Subjects.FirstOrDefault(c => c.SubjectId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Subject obj)
        {

            
        
            if (ModelState.IsValid)
            {
                _db.Subjects.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion

        #region Delete

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Subject category = _db.Subjects.FirstOrDefault(c => c.SubjectId == id);
            if (category == null)
            {
                return NotFound();
            }

            else
            {
                _db.Subjects.Remove(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        #endregion
    }
}
