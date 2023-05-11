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

        public async Task<List<Vaccination>> GetVaccinations()
        {
            return await coronaDb.Vaccinations.ToListAsync();
        }

        public async Task<List<Vaccination>> GetVaccinationById(string id)
        {
            List<Vaccination> vaccinations = await coronaDb.Vaccinations
                .Where(x => x.Id.Equals(id))
                .ToListAsync();

            return vaccinations;
        }

        public async Task<Vaccination> AddVaccination(Vaccination vaccination)
        {
            coronaDb.Vaccinations.Add(vaccination);
            await coronaDb.SaveChangesAsync();
            return vaccination;
        }
    }
}
