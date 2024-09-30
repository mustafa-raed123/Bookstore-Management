using System.ComponentModel.DataAnnotations;

namespace Bookstore_Management.Models.Data.Entities
{
    public class Book
    {

        public int BookId   { get; set; }
        [Required]
        [StringLength(200 , MinimumLength =8 , ErrorMessage = "The title should be between 8 and 200 characters long")]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1,100 , ErrorMessage = "The Price should be in Range 1 to 100")]
        public decimal Price { get; set; }
        [Required]
        public string Genre { get; set; }
    }
}
