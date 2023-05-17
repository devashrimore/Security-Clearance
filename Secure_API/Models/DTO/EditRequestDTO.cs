using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Secure_API.Models.DTO
{
    public class EditRequestDTO
    {
        public int RequestId {get; set;}
        public string RequestStatus {get; set;}
        public int? ActionPerformedBy {get; set;}
    }
}