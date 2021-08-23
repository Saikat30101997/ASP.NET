using Autofac;
using ECommerceSystem.ECommerce.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.ECommerce
{
    public class ECommerceModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ECommerceModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ECommerceDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ECommerceDbContext>().As<IECommerceDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            //builder.RegisterType<StudentRepository>().As<IStudentRepository>()
            //    .InstancePerLifetimeScope();
            //builder.RegisterType<CourseRepository>().As<ICourseRepository>()
            //    .InstancePerLifetimeScope();
            //builder.RegisterType<TrainingUnitOfWork>().As<ITrainingUnitOfWork>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<CourseService>().As<ICourseService>()
            //    .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
