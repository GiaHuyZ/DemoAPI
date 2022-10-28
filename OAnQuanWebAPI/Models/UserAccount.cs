using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace OAnQuanWebAPI.Models
{
    public partial class UserAccount: IdentityUser<int>
    {
        public UserAccount()
        {
            AchievementUsers = new HashSet<AchievementUser>();
            Games = new HashSet<Game>();
            Iventories = new HashSet<Iventory>();
            LoginHistories = new HashSet<LoginHistory>();
            Participants = new HashSet<Participant>();
            UserRedeemCodes = new HashSet<UserRedeemCode>();
        }

        public override int Id { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Status { get; set; }

        public virtual ICollection<AchievementUser> AchievementUsers { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Iventory> Iventories { get; set; }
        public virtual ICollection<LoginHistory> LoginHistories { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<UserRedeemCode> UserRedeemCodes { get; set; }
    }
}
