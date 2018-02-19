using MCMultiverse.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MCMultiverse.Authorization.Handlers
{
    public class DonorRankHandler : AuthorizationHandler<DonorRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DonorRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == "DonorRank"))
            {
                int userRank = Int32.Parse(context.User.FindFirst(c => c.Type == "DonorRank").Value);

                if (requirement.DonorRank == null)
                {
                    context.Succeed(requirement);
                }
                else if (userRank <= requirement.DonorRank)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
