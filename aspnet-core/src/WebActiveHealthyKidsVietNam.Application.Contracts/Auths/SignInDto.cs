using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebActiveHealthyKidsVietNam.Auths
{
    public class SignInDto
    {
        [Required]
        public string UsernameOrEmail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
