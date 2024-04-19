using ProjectMillenium.Core.Entities;
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
    public class ClaimRepository : Repository<Claim>, IClaimRepository
    {
        private readonly ApplicationDbContext _context;
      
        public ClaimRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public Claim GetByName(string claimName)
        {
            return _context.Set<Claim>().Where(x => x.Name == claimName).FirstOrDefault();

        }

      
    } 

}



