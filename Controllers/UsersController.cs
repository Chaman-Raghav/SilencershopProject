using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SilencershopTest.DataAccess;
using SilencershopTest.Interfaces;
using SilencershopTest.Models;

namespace SilencershopTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Local Variable
        private readonly AppDbContext _context;
        private readonly ILogger<UsersController> _logger;
        #endregion Local Variable

        #region Contructor Dependencies Injection
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public UsersController(AppDbContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }
        #endregion Contructor Dependencies Injection

        #region Endpoints
        [HttpGet("GetUserById/{userId:int}")]
        public User GetUser(int userId)
        {
            if(userId == 0)
            {
                return new User { }; //StatusCode(404);
            } else
            {
                try
                {
                    User user = _context.Users.FirstOrDefault(user => user.Id == userId);
                    user.UserRole = _context.UserRoles.SingleOrDefault(role => role.Id == user.UserRoleId);
                    user.UserStatus = _context.UserStatuses.SingleOrDefault(status => status.Id == user.UserStatusId);
                    return user;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("Unexpected Error occured while fetching users from DB", ex.InnerException.Message);
                    throw;
                }
            }
        }

        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            IEnumerable<User> users = _context.Users.ToList();
            return users;
        }

        [HttpPost]
        [Route("AddUser")]
        public OkResult PostUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                Console.WriteLine("There is some error in Adding the user:", ex);
                throw;
            }
            return Ok();
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