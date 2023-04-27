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
              
                return await context.Requests.Include("Visitors").Include("Users").ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Search
        public async Task<IEnumerable<Request>> SearchVisitor(string data)
        {
            var id = data;
            var Empquery = from x in context.Requests.Include("Visitors").AsQueryable();
            if(!string.IsNullOrEmpty(data))
            {
                Empquery = Empquery.Where(x => x.Name.Contains(data) || x.Email.Contains(data)||x.CompanyName.Contains(data));
            }
            return await Empquery.AsNoTracking().ToListAsync();
            
        }

        #endregion
    }
}