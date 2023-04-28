using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Secure_API.Models.Domain;

namespace Secure_API.Repositories
{
    public interface IManager
    {
         Task<IEnumerable<Request>> GetAllRequests();
         Task<IEnumerable<Visitor>> SearchVisitor(string data);
         Task<IEnumerable<Request>> GetApprovedRequests();
         Task<IEnumerable<Request>> GetRejectedRequests();
         Task<User> AddUser(User user);

    }
}