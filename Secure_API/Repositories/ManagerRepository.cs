using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Secure_API.Data;
using Secure_API.Models.Domain;

namespace Secure_API.Repositories
{
    public class ManagerRepository:IManager
    {
        private readonly SecureDbContext context;

        public ManagerRepository(SecureDbContext context)
        {
            this.context = context;
        }
        #region GetAllRequests
        public async Task<IEnumerable<Request>> GetAllRequests()
        {
            try
            {
                return await context.Requests.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}