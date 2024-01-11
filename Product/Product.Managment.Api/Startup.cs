using Autofac;
using Infrastructure.Data;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Product.Managment.Api
{
    public class Startup(IConfiguration Configuration)
    {
        public IConfiguration Configuration { get; set; } = Configuration;
        
        public void ConfigurationContiner(ContainerBuilder builder)
        {

            builder.RegisterModule(new AutoFacModule());
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProductDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("YourConnectionString")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product.MAnagment.Api", Version = "v1" });
            });
        }
    }
}
