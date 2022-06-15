using Microsoft.AspNetCore.Identity;
using Split_IT.Entities;
using Split_IT.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Split_IT.Entities.Models
{
    public class UserRole : IdentityUserRole<string>
    {
        public virtual UserAuth User { get; set; }
        public virtual Role Role { get; set; }
    }
}
