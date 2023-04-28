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


       
    }
}