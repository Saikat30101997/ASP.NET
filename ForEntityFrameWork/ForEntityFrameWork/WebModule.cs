using Autofac;
using ForEntityFrameWork.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForEntityFrameWork
{
    public class WebModule:Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CourseListModel>().AsSelf();

            base.Load(builder);
        }
    }
}
