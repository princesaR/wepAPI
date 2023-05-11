using AutoMapper;
using Dal;
using Dto;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bll
{
    public class VaccinationBll: IVaccinationBll
    {
        IVaccinationDal _vaccinationDal;
        IMapper _mapper;

        public VaccinationBll(IVaccinationDal vaccinationDal, IMapper mapper)
        {
            _vaccinationDal = vaccinationDal;
            _mapper = mapper;
        }

        public VaccinationDto AddVaccination(VaccinationDto vaccinationDto)
        {
            Vaccination vaccination = _mapper.Map<Vaccination>(vaccinationDto);
            _vaccinationDal.AddVaccination(vaccination);
            return vaccinationDto;
        }

        public List<VaccinationDto> GetVaccinationById(string id)
        {
            List<Vaccination> vaccinations = _vaccinationDal.GetVaccinationById(id);
            if (vaccinations.Count == 0)
            {
                return null;
            }
            List<VaccinationDto> vaccinationDtos = _mapper.Map<List<VaccinationDto>>(vaccinations);
            return vaccinationDtos;
        }


        public List<VaccinationDto> GetVaccinations()
        {
            List<Vaccination> vaccinations = _vaccinationDal.GetVaccinations();
            List<VaccinationDto> vaccinationDtos = _mapper.Map<List<VaccinationDto>>(vaccinations);
            return vaccinationDtos;
        }

       

        
    }
}
