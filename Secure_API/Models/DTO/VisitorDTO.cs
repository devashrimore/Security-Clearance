using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Secure_API.Models.DTO
{
    public class VisitorDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Phone {get; set;}
        public string CompanyName {get; set;}
    }
}