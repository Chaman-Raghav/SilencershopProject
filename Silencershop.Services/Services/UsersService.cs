using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Silencershop.ServiceLayer.Services.IServices;
using Silencershop.DataObjects.DataAccess;
using Silencershop.DataObjects.Models;
using System;
using System.Linq;

namespace Silencershop.ServiceLayer.Services
{
    public class UsersService : IUsersService
    {
        #region Local Variable
        private readonly AppDbContext _context;
        private readonly ILogger<UsersService> _logger;
        #endregion Local Variable

        #region Contructor Dependencies Injection
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public UsersService(AppDbContext context, ILogger<UsersService> logger)
        {
            _context = context;
            _logger = logger;
        }
        #endregion Contructor Dependencies Injection

        public User GetUser(int userId)
        {
            User user = new User();
            if (userId == 0)
            {
                return user;
            }
            else
            {
                try
                {
                    user = _context.Users.FirstOrDefault(user => user.Id == userId);
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
        public IActionResult SaveUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return new OkObjectResult("User successfully saved");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogInformation("There is some error in Adding the user:", ex);
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public IActionResult DeleteUser(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(user => (user.Id == userId));
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    return new OkObjectResult("User successfully deleted");
                } else
                {
                    return new OkObjectResult("No User exist with requested UserId");
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Error while deleting the user:", ex.InnerException.Message);
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
