using AutoMapper;
using Dto;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile() {

            CreateMap<Member, MemberDto>();
            CreateMap<MemberDto, Member>();

            CreateMap<Vaccination, VaccinationDto>();
            CreateMap<VaccinationDto, Vaccination>();

            CreateMap<CoronaPatient, CoronaPatientDto>();
            CreateMap<CoronaPatientDto, CoronaPatient>();


        }
    }
}
