using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserForLoginDto:IDTOs
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
