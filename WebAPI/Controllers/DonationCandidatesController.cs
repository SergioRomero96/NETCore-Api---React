using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services.Contracts;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationCandidatesController : ControllerBase
    {
        private readonly IDonationCandidateService _donationCandidateService;

        public DonationCandidatesController(IDonationCandidateService donationCandidateService)
        {
            _donationCandidateService = donationCandidateService;
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
        public async Task<ActionResult<DonationCandidate>> Get(int id)
        {
            var donationCandidate = await _donationCandidateService.Get(id);
            if (donationCandidate == null)
                return NotFound();

            return Ok(donationCandidate);
        }

        // PUT: api/DonationCandidates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DonationCandidate donationCandidate)
        {
            if(id != donationCandidate.Id)
                return BadRequest();

            var candidateUpdated = await _donationCandidateService.Update(id, donationCandidate);

            return Ok(candidateUpdated);
        }

        // POST: api/DonationCandidates
        [HttpPost]
        public async Task<ActionResult<DonationCandidate>> Add(DonationCandidate donationCandidate)
        {
            var candidateAdded = await _donationCandidateService.Save(donationCandidate);

            return Ok(candidateAdded);
        }

        // DELETE: api/DonationCandidates
        [HttpDelete("{id}")]
        public async Task<ActionResult<DonationCandidate>> Delete(int id)
        {
            try
            {
                await _donationCandidateService.Delete(id);

            } catch (Exception e)
            {
                return StatusCode(500);
            }
            return Ok();
        }
    }
}