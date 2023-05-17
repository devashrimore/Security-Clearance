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
       
        #region Add New Visitor
        public async Task<Visitor> AddVisitor(Visitor visitor)
        {
            try
            {
                if (context.Visitors.Where(u => u.Email == visitor.Email).FirstOrDefault() != null)
                {
                return null;
                }
                await context.Visitors.AddAsync(visitor);
                await context.SaveChangesAsync();
                return visitor;
            }
            catch(Exception)
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

    }
}