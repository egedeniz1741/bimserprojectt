using BimserProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimserProject.Core.Interfaces.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
    }
}
