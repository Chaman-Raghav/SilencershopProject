using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Silencershop.ServiceLayer.Services.IServices;
using SilencershopTest.DataAccess;
using SilencershopTest.Models;

namespace SilencershopTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Local Variable
        private AppDbContext _context;
        private IUsersService _usersServicer;
        #endregion Local Variable

        #region Contructor Dependencies Injection
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public UsersController(AppDbContext context, IUsersService usersService)
        {
            _context = context;
            _usersServicer = usersService;
        }
        #endregion Contructor Dependencies Injection

        #region Endpoints
        [HttpGet("GetUserById/{userId:int}")]
        public User GetUser(int userId)
        {
            return _usersServicer.GetUser(userId);
        }

        [HttpGet("GetAllUsers")]
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        [HttpPost]
        [Route("SaveUser")]
        public IActionResult SaveUser([FromForm]User user)
        {
            return _usersServicer.SaveUser(user);
        }

        [HttpDelete]
        [Route("deleteUser/{userId:int}")]
        public OkResult DeleteUser(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(user => (user.Id == userId));
                if(user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                }
            }
            catch(DbUpdateException ex)
            {
                Console.WriteLine("Error while deleting the user:", ex.InnerException.Message);
                throw;
            }
            return Ok();
        }
        [HttpPut]
        [Route("EditUser")]
        public IActionResult EditUserDetails(User user)
        {
            try
            {
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                Console.WriteLine("Error while Updating the user:", ex.InnerException.Message);
                throw;
            }
            return Ok();
        }

        #endregion Endpoints
    }
}