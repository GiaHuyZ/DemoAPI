using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace OAnQuanWebAPI.Models
{
    public partial class UserRole: IdentityRole<int>
    {
        public override int Id { get; set; }
        public string Status { get; set; }

    }
}
