using System;
using System.Collections.Generic;

#nullable disable

namespace OAnQuanWebAPI.Models
{
    public partial class ItemType
    {
        public ItemType()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
