using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEntityFrameWork.Membership.BusinessObjects
{
    public class DeleteRequirementHandler : AuthorizationHandler<DeleteRequirement>
    {
        protected override Task HandleRequirementAsync(
             AuthorizationHandlerContext context,
             DeleteRequirement requirement)
        {
            var claim = context.User.FindFirst("delete_permission");

            if (claim != null && bool.Parse(claim.Value))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
