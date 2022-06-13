using Microsoft.AspNetCore.Identity;
using Split_IT.Entities;
using Split_IT.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_final_DAW.Entities
{
    public class UserRole : IdentityUserRole<string>
    {
        public virtual UserAuth User { get; set; }
        public virtual Role Role { get; set; }
    }
}
