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

        public  List<Member> GetMembers()
        {
            return  coronaDb.Members.ToList();
        }

        public  Member GetMemberById(string id)
        {
            return  coronaDb.Members.FirstOrDefault(x => x.Id.Equals(id));
        }

        public  Member AddMember(Member member)
        {
            coronaDb.Members.Add(member);
             coronaDb.SaveChanges();
            return member;
        }
    }
}
