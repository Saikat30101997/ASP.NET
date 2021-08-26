using Autofac;
using InventorySystem.Inventory.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Inventory
{
    public class InventoryModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public InventoryModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InventoryDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<InventoryDbContext>().As<IInventoryDbContext>()
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
