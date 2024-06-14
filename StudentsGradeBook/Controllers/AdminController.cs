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
        public async Task<IActionResult> CreateUser(AddNewUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var defaultGroupId = 1;
                var user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Role = model.Role,
                    GroupId = defaultGroupId
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

        #region Edit

        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _db.Users.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new CreateUserViewModel
            {                
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
                GroupId = user.GroupId,
                Groups = _db.Groups.ToList() // Get the list of groups from the database
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Edit(CreateUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.FirstOrDefault(c => c.Email == viewModel.Email);
                if (user == null)
                {
                    return NotFound();
                }

                user.FirstName = viewModel.FirstName;
                user.LastName = viewModel.LastName;
                user.Email = viewModel.Email;
                user.Role = viewModel.Role;
                user.GroupId = viewModel.GroupId;              

                _db.Users.Update(user);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            // If we got this far, something failed, redisplay form
            viewModel.Groups = _db.Groups.ToList(); // Repopulate the list of groups
            return View(viewModel);
        }




        #endregion
    }
}
