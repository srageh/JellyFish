using System;
using System.Collections.Generic;

namespace JellyFish.Models
{
    public partial class Skill
    {
        public Skill()
        {
            UserSkills = new HashSet<UserSkill>();
        }

        public int SkillId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
