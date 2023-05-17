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
    public class RequestRepository:IRequest
    {
        private readonly SecureDbContext context;

        public RequestRepository(SecureDbContext context)
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


        #region EditRequest
        public async Task<Request> EditRequest(int requestId, Request request)
        {
            var requestDetail = await context.Requests.FirstOrDefaultAsync(x => x.RequestId == requestId);
            requestDetail.RequestStatus = request.RequestStatus;
            requestDetail.ActionPerformedBy = request.ActionPerformedBy;
            await context.SaveChangesAsync();
            return requestDetail;
            
        }
        #endregion
    }

    
}

