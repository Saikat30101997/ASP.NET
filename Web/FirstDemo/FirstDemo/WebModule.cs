using Autofac;
using FirstDemo.Areas.Admin.Models;
using FristDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FristDemo
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SimpleDatabaseService>().As<IDatabaseService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CourseListModel>().AsSelf();

            base.Load(builder);
        }
    }
}
