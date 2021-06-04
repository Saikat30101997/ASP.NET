using Autofac;
using SerilogDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogDemo
{
    public class WebModule:Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SimpleDataBaseService>().As<IDataBaseService>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
