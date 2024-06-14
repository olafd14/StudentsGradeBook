using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentsGradeBook.Data;
using StudentsGradeBook.Models;
using StudentsGradeBook.Models.VM;
using System.Threading.Tasks;

namespace StudentsGradeBook.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _db;

        public AdminController(UserManager<User> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }


        public IActionResult Index()
        {
            List<User> objUserList = _db.Users.ToList();

            var userRoles = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();

            foreach (var user in objUserList)
            {

                var roleId = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;

            }

            return View(objUserList);
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Role = model.Role
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        public IActionResult AddPayment(string userId)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPayment(Payment obj, string userId)
        {
            if (ModelState.IsValid)
            {
                var payment = new Payment
                {
                    PaymentDate = obj.PaymentDate,
                    PaymentAmount = obj.PaymentAmount,
                    ForWhat = obj.ForWhat,
                    UserId = userId,
                    
                };
                
                _db.Payments.Add(payment); 
                _db.SaveChanges();
                return RedirectToAction("Index"); 
            }

            return View();
        }
    }
}
