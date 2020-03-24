using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories.Contracts;
using WebAPI.Services.Contracts;

namespace WebAPI.Services
{
    public class DonationCandidateService : IDonationCandidateService
    {
        private readonly IDonationCandidateRepository _donationCandidateRepository;

        public DonationCandidateService(IDonationCandidateRepository donationCandidateRepository)
        {
            _donationCandidateRepository = donationCandidateRepository;
        }

        public async Task Delete(int id)
        {
            var dCandidateInDb = await _donationCandidateRepository.GetById(id);
            await _donationCandidateRepository.Delete(dCandidateInDb);
        }

        public async Task<DonationCandidate> Get(int id)
        {
            var candidate = await _donationCandidateRepository.GetById(id);
            return candidate;
        }

        public async Task<IEnumerable<DonationCandidate>> GetAll()
        {
            var candidates = await _donationCandidateRepository.GetAll();
            return candidates;
        }

        public async Task<DonationCandidate> Save(DonationCandidate donationCandidate)
        {
            var candidateInDb = await _donationCandidateRepository.Add(donationCandidate);
            return candidateInDb;
        }

        public async Task<DonationCandidate> Update(int id, DonationCandidate donationCandidate)
        {
            var candidateInDb = await _donationCandidateRepository.GetById(id);
            candidateInDb.FullName = donationCandidate.FullName;
            candidateInDb.Mobile = donationCandidate.Mobile;
            candidateInDb.Email = donationCandidate.Email;
            candidateInDb.BloodGroup = donationCandidate.BloodGroup;
            candidateInDb.Age = donationCandidate.Age;
            candidateInDb.Address = donationCandidate.Address;

            var candidateUpdated = await _donationCandidateRepository.Update(candidateInDb);

            return candidateUpdated;
        }
    }
}
