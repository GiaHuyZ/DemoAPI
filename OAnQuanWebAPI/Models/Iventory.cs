using System;
using System.Collections.Generic;

#nullable disable

namespace OAnQuanWebAPI.Models
{
    public partial class Iventory
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int? ItemId { get; set; }
        public int? PlayerId { get; set; }

        public virtual Item Item { get; set; }
        public virtual UserAccount Player { get; set; }
    }
}
