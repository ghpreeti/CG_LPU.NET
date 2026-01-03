using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionsDemo
{ 
    class Skill
{
    public int SkillID { get; set; }
        public string SkillName { get; set; }

}
class Player : IEnumerable<Skill>
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public Skill[] MySkill { get; set; }

        public IEnumerator<Skill> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
