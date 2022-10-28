using System;
using System.Collections.Generic;

#nullable disable

namespace OAnQuanWebAPI.Models
{
    public partial class Participant
    {
        public int Id { get; set; }
        public int? PlayerId { get; set; }
        public int? GameId { get; set; }
        public int Score { get; set; }

        public virtual Game Game { get; set; }
        public virtual UserAccount Player { get; set; }
    }
}
