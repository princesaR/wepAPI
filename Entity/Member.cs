using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{

    [Table("Members")]
    public class Member
    {

        [Key]
        [MaxLength(9, ErrorMessage = "Id must has 9 digits"), MinLength(9)]
        [Required]
        public string? Id { get; set; }

        [RegularExpression(@"^[\p{L}]+$", ErrorMessage = "First Name must have only alphabetic characters.")]
        [Required]
        public string? FirstName { get; set; }

        [RegularExpression(@"^[\p{L}]+$", ErrorMessage = "Last Name must have only alphabetic characters.")]
        [Required]
        public string? LastName { get; set; }

        [RegularExpression(@"^[\p{L}]+$", ErrorMessage = "City must have only alphabetic characters.")]
        [Required]
        public string? City { get; set; }

        [RegularExpression(@"^[\p{L}]+$", ErrorMessage = "Street must have only alphabetic characters.")]
        [Required]
        public string? Street { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        [MaxLength(12), MinLength(9)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(13), MinLength(10)]
        public string PhoneMobile { get; set; }

        public string? Image { get; set; }

      



    }
}
