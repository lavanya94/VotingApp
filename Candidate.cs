using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Candidate
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int NoOfVotes { get; set; } 
    }
}