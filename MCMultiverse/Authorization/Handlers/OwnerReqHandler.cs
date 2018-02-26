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
    public class OwnerReqHandler : AuthorizationHandler<OwnerRequirement, MCServer>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public OwnerReqHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnerRequirement requirement, MCServer resource)
        {
            Task<ApplicationUser> task = _userManager.GetUserAsync(context.User);

            task.Wait();

            ApplicationUser user = task.Result;

            if (resource.Owner.Id == user.Id || context.User.IsInRole("Admin"))
            {
                context.Succeed(requirement);
            }

            var completedTask = Task.CompletedTask;

            return Task.CompletedTask;
        }
    }
}
