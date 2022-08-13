using System;
using System.Collections.Generic;
using System.Text;

namespace Player.AppUsers.DTOs
{    
    public class LoginResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public string AccessToken { get; set; }
    }
}
