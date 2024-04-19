using ProjectMillenium.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Data.Interfaces
{
    public interface IClaimRepository : IRepository<Claim>
    {
        Claim GetByName(string claimName);
    }
}
