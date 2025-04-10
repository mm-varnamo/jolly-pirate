using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jolly_Pirate.model
{
    public class MembersRegistry
    {
        private List<Member> _members;
        public MembersRegistry(Database database) {
            _members = database.LoadMembersRegistryFromDB();
        }
        public void AddMember(Member member)
        {
            _members.Add(member);
        }
        public void DeleteMember(Guid ID)
        {
            int deletedAmount = _members.RemoveAll(m => m.UniqueID == ID);

            if (deletedAmount == 0) {
                throw new ArgumentOutOfRangeException($"A member with the id {ID} does not exist!");
            }
        }
        public Member GetMemberByID(Guid ID)
        {

            var member = _members.Find(m => m.UniqueID == ID);

            if (member == null)
            {
                throw new ArgumentOutOfRangeException($"A member with the id {ID} does not exist!");
            }

            return member;
        }
        public List<Member> GetMembersList()
        {
            return _members;
        }
    }
}
