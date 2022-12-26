using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebActiveHealthyKidsVietNam.Auths
{
    public class UserCreateDto
    {
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
