using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories.Contexts;
using WebAPI.Repositories.Contracts;

namespace WebAPI.Repositories
{
    public class DonationCandidateRepository : IDonationCandidateRepository
    {
        private readonly DonationDbContext _donationDbContext;

        public DonationCandidateRepository(DonationDbContext donationDbContext)
        {
            _donationDbContext = donationDbContext;
        }

        public async Task<DonationCandidate> Add(DonationCandidate donationCandidate)
        {
            await _donationDbContext.DonationCandidates.AddAsync(donationCandidate);
            await _donationDbContext.SaveChangesAsync();
            return donationCandidate;
        }

        public async Task Delete(DonationCandidate donationCandidate)
        {
            _donationDbContext.DonationCandidates.Remove(donationCandidate);
            await _donationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<DonationCandidate>> GetAll()
        {
            return await _donationDbContext.DonationCandidates.ToListAsync();
        }

        public async Task<DonationCandidate> GetById(int id)
        {
            return await _donationDbContext.DonationCandidates.FindAsync(id);
        }

        public async Task<DonationCandidate> Update(DonationCandidate donationCandidate)
        {
            _donationDbContext.DonationCandidates.Update(donationCandidate);
             await _donationDbContext.SaveChangesAsync();

            return donationCandidate;
        }
    }
}
