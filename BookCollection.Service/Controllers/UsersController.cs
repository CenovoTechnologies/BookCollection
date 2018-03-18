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
        public IActionResult RegisterUser([FromBody] UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User
            {
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                MiddleInitial = userInfo.MiddleInitial,
                Email = userInfo.Email
            };

            _userService.AddNewUser(user, userInfo.Password);

            return Ok(JsonConvert.SerializeObject(_userService.GetUserByEmail(user.Email)));
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginInfo loginInfo)
        {
            var user = _userService.GetUserByEmail(loginInfo.Email);

            if (user == null)
            {
                return NotFound("User not found");
            }

            if (!_userService.SignUserInWithPassword(user, loginInfo.Password))
            {
                return BadRequest("Login Request is not valid");
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