using AttendanceSystem.Common.Utilities;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Common
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
