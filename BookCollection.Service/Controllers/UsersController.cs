using BookCollection.Core;
using BookCollection.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookCollection.Service.Controllers
{
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [Route("Register")]
        [HttpPost]
        public IActionResult RegisterUser(UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User()
            {
                FirstName = userInfo.FirstName,
                MiddleInitial = userInfo.MiddleInitial,
                LastName = userInfo.LastName,
                Email = userInfo.Email
            };

            _userService.AddNewUser(user);

            return Ok(JsonConvert.SerializeObject(user));
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginInfo loginInfo)
        {
            var user = _userService.GetUserByEmail(loginInfo.Email);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(JsonConvert.SerializeObject(user));
        }

        public class UserInfo
        {
            public string FirstName { get; set; }
            public string MiddleInitial { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class LoginInfo
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}