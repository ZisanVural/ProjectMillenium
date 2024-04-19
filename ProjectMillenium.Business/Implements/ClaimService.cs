using ProjectMillenium.Business.Interfaces;
using ProjectMillenium.Core.Entities;
using ProjectMillenium.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Business.Implements
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimRepository;

        public ClaimService(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }

        public void Create(Claim claim)
        {
            _claimRepository.Create(claim);
        }

        public void Delete(Claim claim)
        {
            _claimRepository.Delete(claim);
        }

        
        public void Edit(Claim claim)
        {
            _claimRepository.Edit(claim);
        }

        public List<Claim> GetAll()
        {
            return _claimRepository.GetAll();
        }

        public Claim GetById(int id)
        {
            return _claimRepository.GetById(id);

        }

        public Claim GetByName(string claimName)
        {
            return _claimRepository.GetByName(claimName);
        }


    }
}