using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public interface IMemberBll
    {
        MemberDto AddMember(MemberDto memberDto);
        MemberDto GetMemberById(string id);

        List<MemberDto> GetMembers();

        int GetNotVaccinatedCount();
    }
}
