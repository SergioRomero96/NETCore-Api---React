using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Contracts
{
    public interface IDonationCandidateRepository
    {
        Task<DonationCandidate> GetById(int id);
        Task<IEnumerable<DonationCandidate>> GetAll();
        Task<DonationCandidate> Add(DonationCandidate donationCandidate);
        Task<DonationCandidate> Update(DonationCandidate donationCandidate);
        Task<DonationCandidate> Delete(DonationCandidate donationCandidate);

    }
}
