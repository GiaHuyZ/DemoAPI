using System;
using System.Collections.Generic;

#nullable disable

namespace OAnQuanWebAPI.Models
{
    public partial class LoginHistory
    {
        public int Id { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
        public string IpDevice { get; set; }
        public int? PlayerId { get; set; }

        public virtual UserAccount Player { get; set; }
    }
}
