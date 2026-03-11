using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksApp.Models
{
    [Table("tblBooks")]
    public class BookModel
    {
        [Key]
        public int BookId { get; set;  }
        public string Title { get; set; }
        public string authorName { get; set; }
    }
}
