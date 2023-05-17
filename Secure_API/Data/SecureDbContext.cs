using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Secure_API.Models.Domain;

namespace Secure_API.Data
{
    public class SecureDbContext:DbContext
    {
          public SecureDbContext(DbContextOptions<SecureDbContext>options):base(options)
            {

            }
            public DbSet<User> Users { get; set; }
            public DbSet<Visitor> Visitors { get; set; }
            public DbSet<Request> Requests { get; set;}
        }
    }