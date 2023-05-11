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
        List<Vaccination> GetVaccinations();
        List<Vaccination> GetVaccinationById(string id);
        Vaccination AddVaccination(Vaccination vaccination);
    }
}
