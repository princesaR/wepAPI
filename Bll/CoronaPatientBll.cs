using AutoMapper;
using Dal;
using Dto;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class CoronaPatientBll: ICoronaPatientBll
    {
        ICoronaPatientDal _CoronaPatientDal;

        IMapper _mapper;

        public CoronaPatientBll(ICoronaPatientDal coronaPatientDal, IMapper mapper)
        {
            _CoronaPatientDal = coronaPatientDal;
            _mapper = mapper;
        }


        public CoronaPatientDto AddCoronaPatient(CoronaPatientDto coronaPatientDto)
        {
            CoronaPatient CoronaPatient = _mapper.Map<CoronaPatient>(coronaPatientDto);
            _CoronaPatientDal.AddCoronaPatient(CoronaPatient);
            return coronaPatientDto;
        }

        

        public CoronaPatientDto GetCoronaPatientById(string Id) {
            CoronaPatient CoronaPatient = _CoronaPatientDal.GetCoronaPatientById(Id);
            if (CoronaPatient == null) { return null; }
            CoronaPatientDto coronaPatientDto = _mapper.Map<CoronaPatientDto>(CoronaPatient);
            return coronaPatientDto;

        }

        public List<CoronaPatientDto> GetCoronaPatients()
        {
            List<CoronaPatient> coronaPatients = _CoronaPatientDal.GetCoronaPatients();
            List<CoronaPatientDto> coronaPatientDtos = _mapper.Map<List<CoronaPatientDto>>(coronaPatients);
            return coronaPatientDtos;

        }

        public List<CoronaPatientDto> GetAllCoronaPatientInLastMonth()
        {
            

            DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);

            // Get all active patients from the last month
            List<CoronaPatient> ActiveCoronaPatients = _CoronaPatientDal.GetCoronaPatients().Where(p => p.PositiveResult >= oneMonthAgo).ToList();
            List<CoronaPatientDto> ActiveCoronaPatientsDtos = _mapper.Map<List<CoronaPatientDto>>(ActiveCoronaPatients);
            return ActiveCoronaPatientsDtos;
        }

        public Dictionary<DateTime, int> GetActivePatientsPerDayLastMonth()
        {
            DateTime startDate = DateTime.Now.AddMonths(-1).Date;
            DateTime endDate = DateTime.Now.Date;

            Dictionary<DateTime, int> activePatientsPerDay = new Dictionary<DateTime, int>();

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                int activePatientsCount = _CoronaPatientDal.GetCoronaPatients()
                    .Count(p => p.PositiveResult >= date);

                activePatientsPerDay[date] = activePatientsCount;
            }

            return activePatientsPerDay;
        }
    }
}
