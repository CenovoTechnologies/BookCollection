using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using BookCollection.Core;
using BookCollection.Service.Service;

namespace BookCollection.Service.Controllers
{
    public class UsersController : ApiController
    {
        private UserService us = new UserService();

        // GET: api/Users
        public IEnumerable<User> GetUsers()
        {
            return us.GetAllUsers();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = us.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            us.UpdateUser(user);

            return StatusCode(HttpStatusCode.NoContent);
        }
        
        [Route("api/Users/Register")]
        [HttpPost]
        [ResponseType(typeof(User))]
        public IHttpActionResult RegisterUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            us.AddNewUser(user);

            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        //POST: api/Users/Login
        [ResponseType(typeof(User))]
        public IHttpActionResult Login(User user)
        {
            return Ok(user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteUser(int id)
        {
            bool success = us.DeleteUserById(id);
            if (success)
            {
                return Ok();
            }
            return NotFound();
        }

        private bool UserExists(int id)
        {
            return us.CheckIfUserExistsById(id);
        }
    }
}