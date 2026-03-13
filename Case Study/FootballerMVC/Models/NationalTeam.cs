using System.ComponentModel.DataAnnotations;

namespace FootballerMVC.Models
{
    public class NationalTeam
    {
        public int NationalTeamId { get; set; }

        [Required]
        public string TeamName { get; set; }

        public string Country { get; set; }

        public string Confederation { get; set; }

        public string HeadCoach { get; set; }

        public int FIFA_Ranking { get; set; }
    }
}