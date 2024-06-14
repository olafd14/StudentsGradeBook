using Microsoft.AspNetCore.Mvc;
using StudentsGradeBook.Data;
using StudentsGradeBook.Models;

namespace StudentsGradeBook.Controllers
{
    public class GroupController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GroupController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            List<Group> objCategoryList = _db.Groups.ToList();
            return View(objCategoryList);
        }

        #region Create

        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Group obj)
        {
            var existingGroup = _db.Groups.FirstOrDefault(c => c.GroupName == obj.GroupName);

            if (existingGroup != null)
            {
                ModelState.AddModelError("Name", "A category with the same name already exists.");
            }


            if (ModelState.IsValid)
            {
                
                _db.Groups.Add(obj);
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

            Group group = _db.Groups.FirstOrDefault(c => c.GroupId == id);
            if (group == null)
            {
                return NotFound();
            }
            return View(group);
        }

        [HttpPost]
        public IActionResult Edit(Group obj)
        {



            if (ModelState.IsValid)
            {
                _db.Groups.Update(obj);
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

            Group group = _db.Groups.FirstOrDefault(c => c.GroupId == id);
            if (group == null)
            {
                return NotFound();
            }

            else
            {
                _db.Groups.Remove(group);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        #endregion
    }
}
