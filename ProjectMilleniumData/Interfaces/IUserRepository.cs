using ProjectMillenium.Core.Entity;
using ProjectMillenium.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Data.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUserName(string userName);
        List<User> GetActiveUsers(bool isActive);
        User GetByEmail(string email);       
    }
}
