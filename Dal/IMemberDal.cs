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
        Task<List<Member>> GetMembers();
        Task<Member> GetMemberById(string id);
        Task<Member> AddMember(Member member);
    }
}
