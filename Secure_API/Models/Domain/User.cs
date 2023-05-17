using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Secure_API.Models.Domain
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int uId {get; set;}

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Phone {get; set;}
        public string CompanyName {get; set;}
        public string Role { get; set; }
    }
}

