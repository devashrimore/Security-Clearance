using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Secure_API.Models.Domain;

namespace Secure_API.Repositories
{
    public interface IRequest
    {
         Task<IEnumerable<Request>> GetAllRequests();
         Task<Request> AddRequest(Request SendRequest);
         Task<IEnumerable<Request>> GetApprovedRequests();
         Task<IEnumerable<Request>> GetRejectedRequests();
    
         Task<Request> EditRequest(int requestId, Request request);

    }
}