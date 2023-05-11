using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public  class MemberDto
    {

        // public int MemberCode { get; set; }
        [Required(ErrorMessage = "Id is required.")]
        [MaxLength(9, ErrorMessage = "Id must have 9 digits."), MinLength(9)]
        public string Id { get; set; }

        [RegularExpression(@"^[\p{L}]+$", ErrorMessage = "First Name must have only alphabetic characters.")]
        [Required(ErrorMessage = "First Name is required.")]
        public string? FirstName { get; set; }

        [RegularExpression(@"^[\p{L}]+$", ErrorMessage = "Last Name must have only alphabetic characters.")]
        [Required(ErrorMessage = "Last Name is required.")]
        public string? LastName { get; set; }
        [RegularExpression(@"^[\p{L}]+$", ErrorMessage = "City Name must have only alphabetic characters.")]
        [Required(ErrorMessage = "City Name is required.")]
        public string? City { get; set; }
        [RegularExpression(@"^[\p{L}]+$", ErrorMessage = "Street  Name must have only alphabetic characters.")]
        [Required(ErrorMessage = "Street Name is required.")]
        public string? Street { get; set; }
        [Required(ErrorMessage = "number of address is required.")]
        public int Number { get; set; }
        [Required(ErrorMessage = "DateOfBirth is required.")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Phone is required.")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "PhoneMobile is required.")]
        public string? PhoneMobile { get; set; }
        [RegularExpression(@"^[\p{L}]+$", ErrorMessage = "image name must have only alphabetic characters.")]
        public string? Image { get; set; }
    }
}
