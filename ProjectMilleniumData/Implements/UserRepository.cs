using ProjectMillenium.Core.Entity;
using ProjectMillenium.Data.Context;
using ProjectMillenium.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Data.Implements
{
    public class UserRepository : Repository<User>, IUserRepository
    {


        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<User> GetActiveUsers(bool isActive)
        {
            return _context.Set<User>().Where(x => x.IsActive == isActive).ToList();
        }

        public User GetByEmail(string email)
        {
            return _context.Set<User>().Where(x => x.Email == email).FirstOrDefault();
        }

        public User GetByUserName(string userName)
        {
            return _context.Set<User>().Where(x => x.Name == userName).FirstOrDefault();

        }
       
    }
}
