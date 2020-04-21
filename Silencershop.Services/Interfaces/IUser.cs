using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilencershopTest.Interfaces
{
    public class IUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
