using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTOs.Identity
{
    public class UserDto
    {
        // userdto => response
        public string Email { get; set; }
       public string DisplayName { get; set; }
        public string Token { get; set; }
    }
}
