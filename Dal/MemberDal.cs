using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class MemberDal : IMemberDal
    {
        private readonly CoronaDb coronaDb;

        public MemberDal(CoronaDb coronaDb)
        {
            this.coronaDb = coronaDb;
        }

        public async Task<List<Member>> GetMembers()
        {
            return await coronaDb.Members.ToListAsync();
        }

        public async Task<Member> GetMemberById(string id)
        {
            return await coronaDb.Members.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Member> AddMember(Member member)
        {
            coronaDb.Members.Add(member);
            await coronaDb.SaveChangesAsync();
            return member;
        }
    }
}
