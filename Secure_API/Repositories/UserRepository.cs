using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Secure_API.Data;
using Secure_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Secure_API.Repositories
{
    public class UserRepository:IUser
    {
        private readonly SecureDbContext context;

        public UserRepository(SecureDbContext context)
        {
            this.context = context;
        }


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

         #region Search User
        public async Task<IEnumerable<User>> SearchUser(string data)
        {
            //var id = data;
            var Empquery = from x in context.Users select x;
           // if(!string.IsNullOrEmpty(data))
            //{
                Empquery = Empquery.Where(x => x.Name.Contains(data) || x.Email.StartsWith(data)||x.CompanyName.Contains(data)||x.Role.Contains(data));
            //}
            return await Empquery.AsNoTracking().ToListAsync();
            
        }

        #endregion
    }
}