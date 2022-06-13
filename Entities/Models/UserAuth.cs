using Microsoft.AspNetCore.Identity;
using Proiect_final_DAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Split_IT.Entities.Models
{
    public class UserAuth : IdentityUser
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
