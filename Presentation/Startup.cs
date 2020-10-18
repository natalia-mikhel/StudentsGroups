using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Utils.Modules;
using DAL;
using Domain;
using Domain.UseCases.Groups.Mappings;
using Domain.UseCases.Students.Mappings;
using Presentation.Utils;

namespace Presentation
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
            services.AddAutoMapper(typeof(StudentAutoMapperProfile));
            services.AddAutoMapper(typeof(GroupAutoMapperProfile));
            
            services.RegisterModule<DataAccessModule>(Configuration);
            services.RegisterModule<DomainModule>(Configuration);
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<IDbContext>();
            }
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseExceptionHandlerMiddleware();
            
            app.UseRouting();
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}