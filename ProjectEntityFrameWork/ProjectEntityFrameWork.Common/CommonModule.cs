

using System;
using Autofac;
using Microsoft.Extensions.Options;
using ProjectEntityFrameWork.Common.Utilities;

namespace ProjectEntityFrameWork.Common
{
    public class CommonModule : Module
    {
        public CommonModule()
        {

        }
 
    
        protected override void Load(ContainerBuilder builder)
        {
           
            builder.RegisterType<DateTimeUtility>().As<IDateTimeUtility>()
                .InstancePerLifetimeScope();
            builder.RegisterType<EmailService>().As<IEmailService>()
                .WithParameter("host", "smtp.gmail.com")
                .WithParameter("port", 465)
                .WithParameter("username", "saikat.cse1997@gmail.com")
                .WithParameter("password", "")
                .WithParameter("useSSL", true)
                .WithParameter("from", "saikat.cse1997@gmail.com")
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
