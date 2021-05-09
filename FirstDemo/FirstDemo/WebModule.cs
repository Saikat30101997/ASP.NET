using Autofac;
using FirstDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// autofac shb shmy builtin DI + tar nijoso DI shb gula ek sate jog kore kaaj kore
namespace FirstDemo
{
    public class WebModule: Module // module k inherit korte hobe jeta autofac package a ase
    {
        
         protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SimpleDataBaseService>().As<IDataBaseService>()
                .InstancePerLifetimeScope(); //ek e scoper er vitore ekta instance dibe r ki.. amra alada DI korte parbo stratup ek sate shb likha lagbe na just kn module e kaj korchi seta ConfigureContainer method(startup.cs) e ullhek korte hobe
            base.Load(builder);
        }
    }
}
