using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Entity
{

    [Table("Vaccinations")]
    public class Vaccination
    {
        [Key]
        [Column(Order = 2)]
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Range(1, 4)]
        [Required]
        public int VaccinationId { get; set; }

        [Key]
        [Column(Order = 1)]
        [MaxLength(9, ErrorMessage = "Id must has 9 digits"), MinLength(9)]
        [Required]
        [ForeignKey("Member")]
        public string Id { get; set; }

       
       public virtual Member Member { get; set; }

        [Required]
        public DateTime VaccinationDate { get; set; }

        [RegularExpression(@"^[\p{L}]+$", ErrorMessage = "the manufacturer must have only alphabetic characters.")]
        [Required]
        public string? VaccinationManufacturer { get; set; }
    }
}



