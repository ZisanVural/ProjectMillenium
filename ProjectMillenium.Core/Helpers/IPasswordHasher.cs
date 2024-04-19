using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Core.Helpers
{
    public interface IPasswordHasher
    {
        string HashPassword(string password, out byte[] salt);
    }
}


