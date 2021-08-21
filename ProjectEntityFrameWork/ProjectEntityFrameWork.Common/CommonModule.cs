

using System;
using Autofac;
using ProjectEntityFrameWork.Common.Utilities;

namespace ProjectEntityFrameWork.Common
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           
            builder.RegisterType<DateTimeUtility>().As<IDateTimeUtility>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
