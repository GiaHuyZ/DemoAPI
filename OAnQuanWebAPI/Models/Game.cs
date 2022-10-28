using System;
using System.Collections.Generic;

#nullable disable

namespace OAnQuanWebAPI.Models
{
    public partial class Game
    {
        public Game()
        {
            Participants = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int NumberOfPlayer { get; set; }
        public int? PlayerStartId { get; set; }
        public int? ResultId { get; set; }

        public virtual UserAccount PlayerStart { get; set; }
        public virtual Result Result { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
