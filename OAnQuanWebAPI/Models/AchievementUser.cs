using System;
using System.Collections.Generic;

#nullable disable

namespace OAnQuanWebAPI.Models
{
    public partial class AchievementUser
    {
        public int UserId { get; set; }
        public int AchievementId { get; set; }
        public int Progress { get; set; }
        public bool IsDone { get; set; }

        public virtual Achievement Achievement { get; set; }
        public virtual UserAccount User { get; set; }
    }
}
