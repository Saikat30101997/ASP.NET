using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecondDemo.Services;

namespace SecondDemo
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SimpleDataBaseServcice>().As<IDatabaseService>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
