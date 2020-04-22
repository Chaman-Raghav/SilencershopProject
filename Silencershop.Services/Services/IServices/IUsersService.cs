using Microsoft.AspNetCore.Mvc;
using Silencershop.DataObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Silencershop.ServiceLayer.Services.IServices
{
    public interface IUsersService
    {
        public User GetUser(int userId);
        public IActionResult SaveUser(User user);
    }
}
