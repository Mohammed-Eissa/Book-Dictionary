using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace BookDictionary.Models
{
    public class Auther
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You have to provide a valid full name.")]
        [MinLength(4, ErrorMessage = "Full name musn't be less than 8 characters.")]
        [MaxLength(50, ErrorMessage = "Full name musn't be exceed 50 characters.")]
        [DisplayName("Full Name")]
        public string Name { get; set; }

        [DisplayName("Country")]
        [Range(1, int.MaxValue, ErrorMessage = "Choose a valid Country")]
        [ValidateNever]
        public int CountryId { get; set; }
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Country Country { get; set; }

        [ValidateNever]
        public List<Book> Books { get; set; }
    }
}
