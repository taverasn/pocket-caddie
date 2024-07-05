using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Account
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; } = String.Empty;
        [Required]
        public string Password { get; set; } = String.Empty;
    }
}