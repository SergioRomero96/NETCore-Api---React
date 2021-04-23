using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services.Contracts;
using WebAPI.Services.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationCandidatesController : ControllerBase
    {
        private readonly IDonationCandidateService _donationCandidateService;
        private readonly IMapper _mapper;

        public DonationCandidatesController(IDonationCandidateService donationCandidateService, IMapper mapper)
        {
            _donationCandidateService = donationCandidateService;
            _mapper = mapper;
        }

        // GET: api/DonationCanditates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonationCandidate>>> GetAll()
        {
            var donationCandidates = await _donationCandidateService.GetAll();
            return Ok(donationCandidates);
        }

        // GET: api/DonationCandidates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonationCandidateDTO>> Get(int id)
        {
            var donationCandidateDTO = await _donationCandidateService.Get(id);
            if (donationCandidateDTO == null)
                return NotFound();

            return Ok(donationCandidateDTO);
        }

        // PUT: api/DonationCandidates/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, DonationCandidateDTO donationCandidate)
        {
            if(id != donationCandidate.Id)
                return BadRequest();

            var candidateUpdated = await _donationCandidateService.Update(id, donationCandidate);

            return Ok(candidateUpdated); // return NoContent
        }

        // POST: api/DonationCandidates
        [HttpPost]
        public async Task<ActionResult<DonationCandidateDTO>> Add(DonationCandidateDTO donationCandidate)
        {
            var candidateAdded = await _donationCandidateService.Save(donationCandidate);

            return Ok(candidateAdded);
        }

        // DELETE: api/DonationCandidates
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var candidate = await _donationCandidateService.Delete(id);
                if(candidate == null)
                    return NotFound();

            } catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
            return NoContent();
        }
    }
}