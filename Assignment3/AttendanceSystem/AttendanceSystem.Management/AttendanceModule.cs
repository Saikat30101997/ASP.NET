﻿using AttendanceSystem.Management.Contexts;
using AttendanceSystem.Management.Repositories;
using AttendanceSystem.Management.Services;
using AttendanceSystem.Management.UnitOfWorks;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Management
{
    public class AttendanceModule  : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public AttendanceModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AttendanceDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<AttendanceDbContext>().As<IAttendanceDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentRepository>().As<IStudentRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<AttendanceRepository>().As<IAttendanceRepository>()
              .InstancePerLifetimeScope();

            builder.RegisterType<AttendanceUnitOfWork>().As<IAttendanceUnitOfWork>()
              .InstancePerLifetimeScope();
            builder.RegisterType<StudentService>().As<IStudentService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<AttendanceService>().As<IAttendanceService>()
             .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
