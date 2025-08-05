using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookDictionary.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You have to provide a valid Genre name.")]
        [DisplayName("Full Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        [ValidateNever]
        public List<Book_Genre> Book_Genres { get; set; }
    }
}
