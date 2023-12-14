using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _manager;

        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Users";
            var users = _manager.AuthService.GetAllUsers();
            return View(users);
        }

        // GET
        public IActionResult Create()
        {
            ViewData["Title"] = "Create User";
            return View(new UserDtoForCreation() 
            {
                Roles = new HashSet<string>(_manager.AuthService.Roles.Select(r => r.Name).ToList())
            });
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] UserDtoForCreation userDto)
        {
            var result = await _manager.AuthService.CreateUser(userDto);

            return result.Succeeded ? RedirectToAction("Index") : View();
        }

        // GET
        public async Task<IActionResult> Update([FromRoute(Name = "id")] string id)
        {
            var user = await _manager.AuthService.GetOneUserForUpdate(id);
            ViewData["Title"] = user.UserName;
            return View(user);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] UserDtoForUpdate userDto)
        {
            if (ModelState.IsValid)
            {
                await _manager.AuthService.Update(userDto);

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET
        public async Task<IActionResult> ResetPassword([FromRoute(Name = "id")] string id) 
        {
            ViewData["Title"] = "Change Password";
            return View(new ResetPasswordDto() 
            {
                UserName = id
            });
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto model) 
        {
            var result = await _manager.AuthService.ResetPassword(model);

            return result.Succeeded ? RedirectToAction("Index") : View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOneUser([FromForm] UserDto userDto)
        {
            var result = await _manager.AuthService.DeleteOneUser(userDto.UserName);

            return result.Succeeded ? RedirectToAction("Index") : View();
        }
        
    }
}