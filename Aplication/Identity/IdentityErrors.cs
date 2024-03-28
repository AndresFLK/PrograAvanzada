using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Identity
{
    public static class IdentityErrors
    {
        public static Error NotCreated() => new Error("Identity.NOT_CREATED", $"The user could not be created");
        public static Error InvalidUserOrPassword() => new Error("Identity.INVALID_USER_OR_PASSWORD", $"The user and/or password are invalid");
    }
}
