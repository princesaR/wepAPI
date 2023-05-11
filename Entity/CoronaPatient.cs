using Microsoft.EntityFrameworkCore;
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

    [Table("CoronaPatients")]
    public class CoronaPatient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CoronaPatientId{ get; set; }

       

        [Required]
        [MaxLength(9, ErrorMessage = "Id must has 9 digits"), MinLength(9)]
        [ForeignKey("Member")]
        public string Id { get; set; } // Foreign key property


        public virtual Member Member { get; set; }


        [Required]
        public DateTime PositiveResult { get; set; }

        
        public DateTime RecoveryDate { get; set; }

       


    }
}
