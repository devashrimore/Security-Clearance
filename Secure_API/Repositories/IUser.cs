using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Secure_API.Models.Domain;

namespace Secure_API.Repositories
{
    public interface IUser
    {
        Task<User> AddUser(User user);
        Task<IEnumerable<User>> SearchUser(string data);
    }
}