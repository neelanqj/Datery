using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Datery.API.DTOs
{
    public class UserForRegistrationDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8, MinimumLength =4, ErrorMessage ="You must specify a password between 4 and 8 letters.")]
        public string Password { get; set; }
    }
}
