using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class DonationCandidate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string FullName { get; set; }
        [Column(TypeName = "varchar(16)")]
        public string Mobile { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
        [StringLength(3)]
        public string BloodGroup { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
    }
}
