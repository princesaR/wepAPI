using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface ICoronaPatientDal
    {
        Task<List<CoronaPatient>> GetCoronaPatients();
        Task<CoronaPatient> GetCoronaPatientById(string id);
        Task<CoronaPatient> AddCoronaPatient(CoronaPatient coronaPatient);
    }
}
