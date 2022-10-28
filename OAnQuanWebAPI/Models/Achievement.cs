using System;
using System.Collections.Generic;

#nullable disable

namespace OAnQuanWebAPI.Models
{
    public partial class Achievement
    {
        public Achievement()
        {
            AchievementUsers = new HashSet<AchievementUser>();
        }

        public int Id { get; set; }
        public string AchievementName { get; set; }
        public string Reward { get; set; }

        public virtual ICollection<AchievementUser> AchievementUsers { get; set; }
    }
}
