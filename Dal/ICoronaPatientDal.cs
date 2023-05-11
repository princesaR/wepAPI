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
        List<CoronaPatient> GetCoronaPatients();
        CoronaPatient GetCoronaPatientById(string id);
        CoronaPatient AddCoronaPatient(CoronaPatient coronaPatient);
    }
}
