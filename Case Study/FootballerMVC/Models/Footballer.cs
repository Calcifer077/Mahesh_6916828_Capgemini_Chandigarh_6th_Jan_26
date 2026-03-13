using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballerMVC.Models
{
    public class Footballer
    {
        public int FootballerId { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Position { get; set; }

        public int JerseyNumber { get; set; }

        public string Nationality { get; set; }

        public int Goals { get; set; }

        public int Assists { get; set; }

        public int Appearances { get; set; }

        public decimal MarketValue { get; set; }

        public DateTime DateOfBirth { get; set; }

        // Foreign Keys
        public int ClubId { get; set; }
        public Club Club { get; set; }

        public int NationalTeamId { get; set; }
        public NationalTeam NationalTeam { get; set; }
    }
}