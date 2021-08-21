using Autofac;
using Microsoft.AspNetCore.Authorization;
using ProjectEntityFrameWork.Membership.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEntityFrameWork
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ViewRequirementHandler>().
                As<IAuthorizationHandler>().SingleInstance();  //requirement and requirement handler class er binding  claim based autho er jonno 
            base.Load(builder);
        }
    }
}
