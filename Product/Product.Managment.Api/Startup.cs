using Microsoft.OpenApi.Models;
using System.ComponentModel;

namespace Product.Managment.Api
{
    public class Startup(IConfiguration Configuration)
    {
        public IConfiguration Configuration { get; set; } = Configuration;
        //TODO open it for AutoFAc
        //public void ConfigurationContiner(ContainerBuilder builder)
        //{
        //    builder.RegisterModule(new AutoFacModule());
        //}
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product.MAnagment.Api", Version = "v1" });
            });
        }
    }
}
