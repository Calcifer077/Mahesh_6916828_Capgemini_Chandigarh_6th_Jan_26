using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublishingManagementSystem.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Bio { get; set; }

        // Navigation Property
        public ICollection<AuthorBook>? AuthorBooks { get; set; }
    }
}