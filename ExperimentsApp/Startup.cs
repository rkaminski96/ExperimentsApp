using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ExperimentsApp.Data.DAL;
using ExperimentsApp.Service.Interfaces;
using ExperimentsApp.Service.Services;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ExperimentsApp
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<IExperimentTypeService, ExperimentTypeService>();
            services.AddScoped<IExperimentService, ExperimentService>();
            services.AddScoped<IMachineService, MachineService>();
            services.AddScoped<ISensorService, SensorService>();

            services.AddDbContext<ExperimentsDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("ExperimentsDB"), b => b.MigrationsAssembly("ExperimentsApp.API")));

            services.AddAutoMapper(
               opt => opt.CreateMissingTypeMaps = true,
               Assembly.GetEntryAssembly());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
