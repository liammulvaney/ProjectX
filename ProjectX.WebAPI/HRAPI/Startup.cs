using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjectX.BusinessLogic.Implementations;
using ProjectX.BusinessLogic.Interfaces;
using ProjectX.Context.Context;
using ProjectX.Context.Interface;
using ProjectX.UnitOfWork.Interfaces;
using ProjectX.UnitOfWork.Repository;
using ProjectX.UnitOfWork.UOW.Implementation;
using ProjectX.UnitOfWork.UOW.Interface;

namespace HRAPI
{
    public class Startup
    {
        private IHostingEnvironment _env;
        public Startup(IHostingEnvironment env)
        {
            _env = env;
            Configuration = new ProjectX(_env).ConfigureEnvironment();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //context
            services.AddDbContext<ProjectXContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("ProjectX")));
            services.AddTransient<IContext, ProjectXContext>();
            services.AddTransient<IRepository, Repository>();
            services.AddTransient<IUOW, UOW>();
            //business layer
            services.AddTransient<IEmployeeBL, EmployeesBL>();
            services.AddSingleton<ProjectX>();
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

    public class ProjectX
    {
        private IConfigurationRoot Configuration { get; }
        public IHostingEnvironment Environment { get; private set; }

        public ProjectX(IHostingEnvironment environment)
        {
            this.Environment = environment;
            string appsettings = System.IO.Path.Combine(this.Environment.ContentRootPath, "appsettings.json");
            string appsettingsDevelopment = System.IO.Path.Combine(this.Environment.ContentRootPath, $"appsettings.{ this.Environment.EnvironmentName }.json");
            var builder = new ConfigurationBuilder()
                            .AddJsonFile(appsettings, optional: false, reloadOnChange: true)
                            .AddJsonFile(appsettingsDevelopment, optional: true)
                            .AddEnvironmentVariables();

            this.Configuration = builder.Build();
            builder.AddEnvironmentVariables();
            
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot ConfigureEnvironment()
        {
            return this.Configuration;
        }
    }
}
