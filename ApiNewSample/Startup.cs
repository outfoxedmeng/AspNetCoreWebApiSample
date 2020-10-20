using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ApiNewSample.Data;
using ApiNewSample.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApiNewSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RoutineDbContext>(options =>
            {
                options
                //.UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=api200928a;Trusted_Connection=True;MultipleActiveResultSets=true");
            });

            services.AddControllers(config =>
            {
                config.ReturnHttpNotAcceptable = true;//p8:若response没有对应的formatter，返回406 NotAcceptable
            })
                .AddXmlDataContractSerializerFormatters();//P8:内容协商

            //P10
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddScoped<ICompanyRepository, CompanyRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name
                && level == LogLevel.Information
            )
            .AddConsole();

        });

    }
}
