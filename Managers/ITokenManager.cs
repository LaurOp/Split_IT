using Split_IT.Entities;
using Split_IT.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Split_IT.Managers
{
    public interface ITokenManager
    {
        Task<string> CreateToken(UserAuth user);
    }
}
