using Autofac;
using ForEntityFrameWork.Common.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Common
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<DateTimeUtility>()
                .As<IDateTimeUtlity>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
