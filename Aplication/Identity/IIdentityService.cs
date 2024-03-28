using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Identity
{
    internal interface IIdentityService : IAccountService
    {
        Task<bool> HasAccess(string email, string controller, string action);
    }
}
