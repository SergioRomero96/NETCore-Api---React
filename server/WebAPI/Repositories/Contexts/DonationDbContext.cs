using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Contexts
{
    public class DonationDbContext: DbContext
    {
        public DonationDbContext(DbContextOptions<DonationDbContext> options) :base(options)
        {

        }

        public DbSet<DonationCandidate> DonationCandidates { get; set; }
    }
}
