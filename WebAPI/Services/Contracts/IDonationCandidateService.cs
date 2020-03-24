using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services.Contracts
{
    public interface IDonationCandidateService
    {
        Task<IEnumerable<DonationCandidate>> GetAll();
        Task<DonationCandidate> Get(int id);
        Task<DonationCandidate> Save(DonationCandidate donationCandidate);
        Task<DonationCandidate> Update(int id, DonationCandidate donationCandidate);
        Task Delete(int id);
    }
}
