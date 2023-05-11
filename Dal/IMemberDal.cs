using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IMemberDal
    {
        List<Member> GetMembers();
        Member GetMemberById(string id);
        Member AddMember(Member member);
    }
}
