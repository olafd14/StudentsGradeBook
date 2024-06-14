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
    }
}
