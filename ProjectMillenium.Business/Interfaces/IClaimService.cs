using ProjectMillenium.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Business.Interfaces
{
    public interface IClaimService

    {
        void Create(Claim Entity);
        void Delete(Claim Entity);
        void Edit(Claim Entity);
        Claim GetById(int id);
        Claim GetByName(string claimName);
        List<Claim> GetAll();

    }
}
