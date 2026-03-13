using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublishingManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string ISBN { get; set; }

        public DateTime PublishedDate { get; set; }

        // Navigation Property
        public ICollection<AuthorBook>? AuthorBooks { get; set; }
    }
}