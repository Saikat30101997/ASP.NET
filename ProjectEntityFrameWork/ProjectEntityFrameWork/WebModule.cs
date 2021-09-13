using Autofac;
using Microsoft.AspNetCore.Authorization;
using ProjectEntityFrameWork.Common.Utilities;
using ProjectEntityFrameWork.Membership.BusinessObjects;
using ProjectEntityFrameWork.Models;
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
            
            base.Load(builder);
        }
    }
}
