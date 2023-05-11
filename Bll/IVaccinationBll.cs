using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public interface IVaccinationBll
    {
        VaccinationDto AddVaccination(VaccinationDto vaccinationDto);
        List<VaccinationDto> GetVaccinationById(string Id);

        List<VaccinationDto> GetVaccinations();


      
    }
}
