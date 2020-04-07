using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services.DTOs;

namespace WebAPI.Services.Contracts
{
    public interface IDonationCandidateService
    {
        Task<IEnumerable<DonationCandidateDTO>> GetAll();
        Task<DonationCandidateDTO> Get(int id);
        Task<DonationCandidateDTO> Save(DonationCandidateDTO donationCandidate);
        Task<DonationCandidateDTO> Update(int id, DonationCandidateDTO donationCandidate);
        Task<DonationCandidateDTO> Delete(int id);
    }
}
