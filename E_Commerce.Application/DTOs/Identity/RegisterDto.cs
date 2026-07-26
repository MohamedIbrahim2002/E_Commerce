using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTOs.Identity
{
    public class RegisterDto
    {

        // login => request
        [Required(ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
       
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Display name is required")]
        public string DisplayName { get; set; }
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
