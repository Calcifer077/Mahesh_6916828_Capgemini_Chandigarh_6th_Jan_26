using System.ComponentModel.DataAnnotations;

namespace FootballerMVC.Models
{
    public class Club
    {
        public int ClubId { get; set; }

        [Required]
        public string ClubName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int FoundedYear { get; set; }

        public string StadiumName { get; set; }

        public int StadiumCapacity { get; set; }
    }
}