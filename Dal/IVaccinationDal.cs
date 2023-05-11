using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IVaccinationDal
    {
        Task<List<Vaccination>> GetVaccinations();
        Task<List<Vaccination>> GetVaccinationById(string id);
        Task<Vaccination> AddVaccination(Vaccination vaccination);
    }
}
