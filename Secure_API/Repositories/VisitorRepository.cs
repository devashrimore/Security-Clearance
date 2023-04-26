using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Secure_API.Data;
using Secure_API.Models.Domain;

namespace Secure_API.Repositories
{
    public class VisitorRepository:IVisitor
    {
        private readonly SecureDbContext context;

        public VisitorRepository(SecureDbContext context)
        {
            this.context = context;
        }
         #region AddRequest
        public async Task<Request> AddRequest(Request SendRequest)
        {
            try
            {
               
               // Request.RequestStatus = "Initiated";
                await context.AddAsync(SendRequest);
                await context.SaveChangesAsync();
                return SendRequest;
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion

    }
}