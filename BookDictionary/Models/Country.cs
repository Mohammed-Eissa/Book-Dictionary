using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookDictionary.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You have to provide a valid country name.")]
        [MinLength(4, ErrorMessage = "Country name musn't be less than 8 characters.")]
        [MaxLength(60, ErrorMessage = "Country name musn't be exceed 60 characters.")]
        [DisplayName("Full Name")]
        public string Name { get; set; }

        [ValidateNever]
        public List<Auther> Authers { get; set; }
    }
}
