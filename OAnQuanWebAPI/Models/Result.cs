using System;
using System.Collections.Generic;

#nullable disable

namespace OAnQuanWebAPI.Models
{
    public partial class Result
    {
        public Result()
        {
            Games = new HashSet<Game>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
