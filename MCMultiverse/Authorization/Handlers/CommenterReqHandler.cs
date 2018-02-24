using MCMultiverse.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCMultiverse.Authorization.Handlers
{
    public class CommenterReqHandler : AuthorizationHandler<CommenterRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CommenterRequirement requirement)
        {
            throw new NotImplementedException();
        }
    }
}
