using Autofac;
using InventorySystem.Inventory.Contexts;
using InventorySystem.Inventory.Repositories;
using InventorySystem.Inventory.Services;
using InventorySystem.Inventory.UnitOfWorks;


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

            builder.RegisterType<ProductRepository>().As<IProductRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<StockRepository>().As<IStockRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<InventoryUnitOfWork>().As<IInventoryUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductService>().As<IProductService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
