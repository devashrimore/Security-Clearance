using System.Reflection.Metadata;
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
        public async Task<IEnumerable<Visitor>> SearchVisitor(string data)
        {
            //var id = data;
            var Empquery = from x in context.Visitors select x;
           // if(!string.IsNullOrEmpty(data))
            //{
                Empquery = Empquery.Where(x => x.Name.Contains(data) || x.Email.StartsWith(data)||x.CompanyName.Contains(data));
            //}
            return await Empquery.AsNoTracking().ToListAsync();
            
        }

        #endregion
    
        #region Get Approved Requests
        public async Task<IEnumerable<Request>> GetApprovedRequests()
        {
            string Status = "Approved";
            var Empquery = from x in context.Requests select x;
            if (!string.IsNullOrEmpty(Status))
            {
                Empquery = Empquery.Where(x => x.RequestStatus.Equals(Status));
            }
            return await Empquery.AsNoTracking().ToListAsync();
        }

        #endregion

        #region Get Rejected Requests
        public async Task<IEnumerable<Request>> GetRejectedRequests()
        {
            string Status = "Rejected";
            var Empquery = from x in context.Requests select x;
            if (!string.IsNullOrEmpty(Status))
            {
                Empquery = Empquery.Where(x => x.RequestStatus.Equals(Status));
            }
            return await Empquery.AsNoTracking().ToListAsync();
        }

        #endregion

        #region Add New User
        public async Task<User> AddUser(User user)
        {
            try
            {
                if (context.Users.Where(u => u.Email == user.Email).FirstOrDefault() != null)
                {
                return null;
                }
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
                return user;
            }
            catch(Exception)
            {
                throw;

            }
        }
        #endregion
    }

    
}