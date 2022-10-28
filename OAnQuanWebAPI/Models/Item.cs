using System;
using System.Collections.Generic;

#nullable disable

namespace OAnQuanWebAPI.Models
{
    public partial class Item
    {
        public Item()
        {
            Iventories = new HashSet<Iventory>();
        }

        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public double Price { get; set; }
        public int? TypeId { get; set; }

        public virtual ItemType Type { get; set; }
        public virtual ICollection<Iventory> Iventories { get; set; }
    }
}
