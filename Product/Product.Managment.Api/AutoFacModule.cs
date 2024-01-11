using Application.Comman;
using Autofac;
using Infrastructure.Data;
using System.Reflection;

namespace Product.Managment.Api
{
    public class AutoFacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var asm = new[]
            {
                Assembly.GetExecutingAssembly(),
                Assembly.Load("Application"),
                Assembly.Load("Infrastructure"),
            };
            builder.RegisterInstance(MappingConfig.Configure);

            builder.RegisterAssemblyTypes(asm)
                .AsImplementedInterfaces()
                .PublicOnly();
            builder.RegisterType<ProductDbContext>().AsSelf();
        }
    }
}