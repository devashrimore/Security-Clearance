using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Secure_API.Repositories;
using Secure_API.Models.Domain;

namespace Secure_API.Services
{
    public class VisitorService
    {
        private IVisitor _VisitorRepository;
        

        public VisitorService(IVisitor VisitorRepository)
        {
            _VisitorRepository = VisitorRepository;
        }

        public async Task<Request> AddRequest(Request SendRequest)
        {
             return await _VisitorRepository.AddRequest(SendRequest);
        }
    }
}