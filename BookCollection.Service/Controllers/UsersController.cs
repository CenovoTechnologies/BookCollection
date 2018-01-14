using System.Web.Http;
using BookCollection.Core;
using BookCollection.Service.Service;
using Newtonsoft.Json;

namespace BookCollection.Service.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private UserService us = new UserService();
        
        [Route("Register")]
        [HttpPost]
        public IHttpActionResult RegisterUser(UserInfo userInfo)
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

            us.AddNewUser(user);

            return Ok(JsonConvert.SerializeObject(user));
        }

        [Route("Login")]
        [HttpPost]
        public IHttpActionResult Login(LoginInfo loginInfo)
        {
            var user = us.GetUserByEmail(loginInfo.Email);

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