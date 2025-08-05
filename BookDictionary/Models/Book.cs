using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace BookDictionary.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You have to provide a Book Title.")]
        [DisplayName("Book Title")]
        public string Title { get; set; }
        public string Description { get; set; }
        [ValidateNever]
        [DisplayName("Author")]
        [Range(1, int.MaxValue, ErrorMessage = "Choose a valid Author")]
        public int AuthorId { get; set; }
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Auther Author { get; set; }

        [ValidateNever]
        public List<Book_Genre> Book_Genres { get; set; }
    }
}
