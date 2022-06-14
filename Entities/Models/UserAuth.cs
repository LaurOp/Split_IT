using Microsoft.AspNetCore.Identity;
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
