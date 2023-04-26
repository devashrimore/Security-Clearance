using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Secure_API.Models.Domain
{
    public class Visitor
    {
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int vId {get; set;}

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Phone {get; set;}
        public string CompanyName {get; set;}
        
    }
}