using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes;

namespace Dto
{
    public  class VaccinationDto
    {

       
        public int VaccinationId { get; set; }



        [Required(ErrorMessage = "Id is required.")]
        [MaxLength(9, ErrorMessage = "Id must have 9 digits."), MinLength(9)]
        [ExistingMemberId]
        public string Id { get; set; }

        [Required(ErrorMessage = "Vaccination Date is required.")]
        public DateTime VaccinationDate { get; set; }

        [RegularExpression(@"^[\p{L}]+$", ErrorMessage = "The manufacturer must have only alphabetic characters.")]
        [Required(ErrorMessage = "Vaccination Manufacturer is required.")]
        public string? VaccinationManufacturer { get; set; }
    }
}
