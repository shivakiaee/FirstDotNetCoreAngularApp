using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Model;
using Newtonsoft.Json.Serialization;
using Repository;
using Service;

namespace FirstDotNetCoreAngularApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => {
                    var resolver = options.SerializerSettings.ContractResolver;
                    if(resolver!=null)
                    {
                        (resolver as DefaultContractResolver).NamingStrategy = null;
                    }
                    })
                ;

            services.AddCors();
            services.AddDbContext<ShipmentContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ShipmentDBConnection")));
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IBaseService<Province>, BaseService<Province>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBaseService<City>, BaseService<City>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ShipmentContext>();
                context.Database.EnsureCreated();
            }

            app.UseCors(
                options => options.WithOrigins(Configuration.GetSection("Angular7Url").Value)
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseMvc();
        }
    }
}
