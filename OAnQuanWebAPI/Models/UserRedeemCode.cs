using System;
using System.Collections.Generic;

#nullable disable

namespace OAnQuanWebAPI.Models
{
    public partial class UserRedeemCode
    {
        public int UserId { get; set; }
        public int RedeemId { get; set; }

        public virtual RedeemCode Redeem { get; set; }
        public virtual UserAccount User { get; set; }
    }
}
