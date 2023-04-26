using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Secure_API.Models.Domain
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId {get; set;}

        public int VisitorId { get; set; }
        public string Address { get; set; }
        public string VisitingTo { get; set; }
        public string Purpose { get; set; }
       
        public DateTime? RequestDate {get; set;}
        public DateTime? VisitDate {get; set;}
        public string EntryTime {get; set;}
        public string ExitTime {get; set;}
        public string RequestStatus {get; set;}
        public int? ActionPerformedBy {get; set;}


        [ForeignKey("VisitorId")]
        public Visitor Visitors { get; set; }

        [ForeignKey("ActionPerformedBy")]
        public User Users { get; set; }
    }
}