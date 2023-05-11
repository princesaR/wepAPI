using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class VaccinationDal : IVaccinationDal
    {
        private readonly CoronaDb coronaDb;

        public VaccinationDal(CoronaDb coronaDb)
        {
            this.coronaDb = coronaDb;
        }

        public List<Vaccination> GetVaccinations()
        {
            return coronaDb.Vaccinations.ToList();
        }

        public List<Vaccination> GetVaccinationById(string id)
        {
            List<Vaccination> vaccinations =  coronaDb.Vaccinations
                .Where(x => x.Id.Equals(id))
                .ToList();

            return vaccinations;
        }

        public Vaccination AddVaccination(Vaccination vaccination)
        {
            coronaDb.Vaccinations.Add(vaccination);
             coronaDb.SaveChanges();
            return vaccination;
        }
    }
}
