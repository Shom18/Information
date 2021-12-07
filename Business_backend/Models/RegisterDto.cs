using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business_backend.Models
{
    public class RegisterDto
    {
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Pass_word { get; set; }
    }
}
