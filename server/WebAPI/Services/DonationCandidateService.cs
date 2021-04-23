using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories.Contracts;
using WebAPI.Services.Contracts;
using WebAPI.Services.DTOs;

namespace WebAPI.Services
{
    public class DonationCandidateService : IDonationCandidateService
    {
        private readonly IDonationCandidateRepository _donationCandidateRepository;
        private readonly IMapper _mapper;

        public DonationCandidateService(IDonationCandidateRepository donationCandidateRepository, IMapper mapper)
        {
            _donationCandidateRepository = donationCandidateRepository;
            _mapper = mapper;
        }

        public async Task<DonationCandidateDTO> Delete(int id)
        {
            var dCandidateInDb = await _donationCandidateRepository.GetById(id);
            
            var candidateDeleted = await _donationCandidateRepository.Delete(dCandidateInDb);

            return _mapper.Map<DonationCandidateDTO>(candidateDeleted);
        }

        public async Task<DonationCandidateDTO> Get(int id)
        {
            var candidate = await _donationCandidateRepository.GetById(id);
            var candidateDTO = _mapper.Map<DonationCandidateDTO>(candidate);
            return candidateDTO;
        }

        public async Task<IEnumerable<DonationCandidateDTO>> GetAll()
        {
            var candidates = await _donationCandidateRepository.GetAll();
            var candidatesDTO = _mapper.Map<IEnumerable<DonationCandidateDTO>>(candidates);
            return candidatesDTO;
        }

        public async Task<DonationCandidateDTO> Save(DonationCandidateDTO donationCandidateDTO)
        {
            var donationCandidate = _mapper.Map<DonationCandidate>(donationCandidateDTO);
            var candidateInDb = await _donationCandidateRepository.Add(donationCandidate);
            return _mapper.Map<DonationCandidateDTO>(candidateInDb);
        }

        public async Task<DonationCandidateDTO> Update(int id, DonationCandidateDTO donationCandidate)
        {
            var candidateInDb = await _donationCandidateRepository.GetById(id);
            candidateInDb.FullName = donationCandidate.FullName;
            candidateInDb.Mobile = donationCandidate.Mobile;
            candidateInDb.Email = donationCandidate.Email;
            candidateInDb.BloodGroup = donationCandidate.BloodGroup;
            candidateInDb.Age = donationCandidate.Age;
            candidateInDb.Address = donationCandidate.Address;

            var candidateUpdated = await _donationCandidateRepository.Update(candidateInDb);

            return _mapper.Map<DonationCandidateDTO>(candidateUpdated);
        }
    }
}
