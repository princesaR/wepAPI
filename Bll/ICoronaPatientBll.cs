using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public interface ICoronaPatientBll
    {
        CoronaPatientDto AddCoronaPatient(CoronaPatientDto coronaPatientDto);
        CoronaPatientDto GetCoronaPatientById(string Id);

        List<CoronaPatientDto> GetCoronaPatients();

        List<CoronaPatientDto> GetAllCoronaPatientInLastMonth();

        public Dictionary<DateTime, int> GetActivePatientsPerDayLastMonth();

        
    }
}
