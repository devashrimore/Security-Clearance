using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Secure_API.Models.DTO
{
    public class RequestDTO
    {
        public double RequestId {get; set;}
        public double VisitorId { get; set; }
        public string Address { get; set; }
        public string VisitingTo { get; set; }
        public string Purpose { get; set; }
       
        public DateTime? RequestDate {get; set;}
        public DateTime? VisitDate {get; set;}
        public string EntryTime {get; set;}
        public string ExitTime {get; set;}
        public string RequestStatus {get; set;}
       // public double ActionPerformedBy {get; set;}
    }
}