using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Data
{
    public class DataModule : Module // module k inherit korte hobe jeta autofac package a ase
    {
        private readonly string _connectionString;
        private readonly string _migrationAssmeblyName;
        public DataModule(string connectionString,string migrationAssemblyName) //Di er maddhome amdr project er sathe bining korar jonno 
        {
            _connectionString = connectionString;
            _migrationAssmeblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            //with parameter diye declare kore dite hobe binnd korar jonno 
            builder.RegisterType<TrainingContext>().AsSelf()
                .WithParameter("connectionString",_connectionString)//eta mane knu interface er sate bind korbena nje nje bind hobee
                .WithParameter("migrationAssemblyName",_migrationAssmeblyName)
                .InstancePerLifetimeScope(); //ek e scoper er vitore ekta instance dibe r ki.. amra alada DI korte parbo stratup ek sate shb likha lagbe na just kn module e kaj korchi seta ConfigureContainer method(startup.cs) e ullhek korte hobe
            base.Load(builder);
        }
    }
}
