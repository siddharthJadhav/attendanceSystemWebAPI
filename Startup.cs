using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AttendanceSystemWebAPI.Models;
using AttendanceSystemWebAPI.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AttendanceSystemWebAPI
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
            services.AddControllers();
            IConfigurationRoot config = (Microsoft.Extensions.Configuration.IConfigurationRoot)new ConfigurationBuilder().SetBasePath(System.IO.Directory.GetCurrentDirectory()) //From NuGet Package Microsoft.Extensions.Configuration.Json
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();
            string DBConstr = config["mysqlConnection"];
            services.AddDbContext<mysqlContextDAL>(options => options.UseMySql(DBConstr));
            // services.AddDbContext<mysqlContextDAL>(options => options.UseMySql("server=localhost;userid=root;pwd=rootroot;port=3306;database=EmployeeDB;sslmode=none;"));
            services.AddIdentity<ApplicationUserModel, IdentityRole>().AddEntityFrameworkStores<mysqlContextDAL>().AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
