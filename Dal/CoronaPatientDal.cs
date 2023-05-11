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

        public async Task<List<CoronaPatient>> GetCoronaPatients()
        {
            return await Task.FromResult(coronaDb.CoronaPatients.ToList());
        }

        public async Task<CoronaPatient> GetCoronaPatientById(string id)
        {
            var coronaPatient = await Task.FromResult(coronaDb.CoronaPatients.FirstOrDefault(x => x.Id.Equals(id)));
            return coronaPatient;
        }

        public async Task<CoronaPatient> AddCoronaPatient(CoronaPatient coronaPatient)
        {
            coronaDb.CoronaPatients.Add(coronaPatient);
            await coronaDb.SaveChangesAsync();
            return coronaPatient;
        }
    }
}
