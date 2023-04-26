using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Secure_API.Models.Domain;

namespace Secure_API.Repositories
{
    public interface IVisitor
    {
     Task<Request> AddRequest(Request SendRequest);
    }
}