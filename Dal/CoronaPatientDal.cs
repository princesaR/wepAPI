using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class CoronaPatientDal : ICoronaPatientDal
    {
        private readonly CoronaDb coronaDb;

        public CoronaPatientDal(CoronaDb coronaDb)
        {
            this.coronaDb = coronaDb;
        }

        public  List<CoronaPatient> GetCoronaPatients()
        {
            return (coronaDb.CoronaPatients.ToList());
        }

        public CoronaPatient GetCoronaPatientById(string id)
        {
            var coronaPatient = coronaDb.CoronaPatients.FirstOrDefault(x => x.Id.Equals(id));
            return coronaPatient;
        }

        public CoronaPatient AddCoronaPatient(CoronaPatient coronaPatient)
        {
            coronaDb.CoronaPatients.Add(coronaPatient);
             coronaDb.SaveChanges();
            return coronaPatient;
        }
    }
}
