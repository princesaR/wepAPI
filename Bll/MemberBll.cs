using AutoMapper;
using Dal;
using Entity;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Bll
{
    public class MemberBll: IMemberBll
    {
        IMemberDal _memberDal;
        IMapper _mapper;
        IVaccinationDal _vaccinationDal;
        public MemberBll(IMemberDal memberDal, IMapper mapper, IVaccinationDal vaccinationDal)
        {
            _memberDal = memberDal;
            _mapper = mapper;
            _vaccinationDal = vaccinationDal;
        }

        public  MemberDto AddMember(MemberDto memberDto)
        {
            Member member = _mapper.Map<Member>(memberDto);
             _memberDal.AddMember(member);
            return memberDto;
        }

        public MemberDto GetMemberById(string id)
        {
            Member member = _memberDal.GetMemberById(id);
            if (member == null)
            {
                return null;
            }
            MemberDto memberDto = _mapper.Map<MemberDto>(member);
            return memberDto;
        }


        public List<MemberDto> GetMembers()
        {
            List<Member> memebrs = _memberDal.GetMembers();
            List<MemberDto> memberDtos = _mapper.Map<List<MemberDto>>(memebrs);
            return memberDtos;

        }

        

       
        int IMemberBll.GetNotVaccinatedCount()
        {
            List<Member> members = _memberDal.GetMembers();
            HashSet<string> vaccinatedMemberIds = new HashSet<string>(_vaccinationDal.GetVaccinations().Select(v => v.Id));
            int notVaccinatedCount = members.Count(member => !vaccinatedMemberIds.Contains(member.Id));
            return notVaccinatedCount;
        }
    }
}
