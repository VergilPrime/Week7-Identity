using MCMultiverse.Data;
using MCMultiverse.Models.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCMultiverse.Models.AuthorizationRequirements
{
    public class OwnsServerRequirement : IAuthorizationRequirement
    {
        public int ServerId { get; set; }

        private readonly ApplicationDbContext _context { get; }

        private readonly UserManager<ApplicationUser> _user { get; }

        public OwnsServerRequirement(ApplicationDbContext context, UserManager<ApplicationUser> user, int serverId)
        {
            _context = context;
            _user = user;
            ServerId = serverId;
        }

    }

    public class OwnsServerRequirementHandler : AuthorizationHandler<OwnsServerRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext handlerContext,
                                                   OwnsServerRequirement requirement)
        {
            if (handlerContext._context.MCServers.FirstOrDefault(server => server.Id = requirement.ServerId) == null) return Task.CompletedTask; // TODO: Return server not found

            MCServer server = handlerContext._context.MCServers.FirstOrDefault(server => server.Id = requirement.ServerId);
            if (server.Owner == _user.)
                handlerContext.Succeed(requirement);

            //TODO: Use the following if targeting a version of
            //.NET Framework older than 4.6:
            //      return Task.FromResult(0);
            return Task.CompletedTask;
        }
    }

}
