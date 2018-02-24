using MCMultiverse.Authorization.Requirements;
using MCMultiverse.Models;
using MCMultiverse.Models.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCMultiverse.Authorization.Handlers
{
    public class OwnerReqHandler : AuthorizationHandler<OwnerRequirement,MCServer>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public OwnerReqHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnerRequirement requirement)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            int mCServerId = context
            Services.
            if(server.Owner.Id == user.Id)
            {

            }
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnerRequirement requirement, MCServer mCServer)
        {
            ApplicationUser user = await _userManager.GetUserAsync(context.User);
            if(mCServer.Owner.Id != user.Id && !context.User.IsInRole("Admin"))
            {
                context.Fail();
            }
            else
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
