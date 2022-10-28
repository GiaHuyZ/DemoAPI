using System;
using System.Collections.Generic;

#nullable disable

namespace OAnQuanWebAPI.Models
{
    public partial class RedeemCode
    {
        public RedeemCode()
        {
            UserRedeemCodes = new HashSet<UserRedeemCode>();
        }

        public int Id { get; set; }
        public string Code { get; set; }

        public virtual ICollection<UserRedeemCode> UserRedeemCodes { get; set; }
    }
}
