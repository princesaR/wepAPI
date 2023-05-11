using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes;

namespace Dto
{
    public  class CoronaPatientDto


    {


        //   public int code { get; set; }

        [Required(ErrorMessage = "Id is required.")]
        [MaxLength(9, ErrorMessage = "Id must have 9 digits."), MinLength(9)]
        [ExistingMemberId]
        public string Id { get; set; }

       
        [Required(ErrorMessage = "Positive Result date is required.")]
       
        public DateTime PositiveResult { get; set; }


        public DateTime RecoveryDate { get; set; }

        
    }
}
