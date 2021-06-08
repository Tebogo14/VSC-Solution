using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using VSC.Entityframeworkcore;
using VSC.Entityframeworkcore.EntityFramework;
using VSC_Solution.Services.Customer;
using VSC_Solution.Services.Import;
using VSC_Solution.Services.Location;

namespace VSC_Solution
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<VSCDbContext>(option =>
                option.UseNpgsql(Configuration.GetConnectionString(VSCConts.ConnectionStringName)));


            //services
            services.AddScoped<IImportService, ImportService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("version1", new OpenApiInfo
                {
                    Version = "Version1",
                    Title = "VSC Solution API",
                    Description = "This are API for VSC Solution"
                });
            });

            services.AddSwaggerDocument();

            services.AddCors(
                options => options.AddPolicy(
                MyAllowSpecificOrigins,
                    builder => builder
                .WithOrigins(Configuration["App:CorsOrigins"].Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray()
                ).AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(swagger =>
            {
                swagger.SwaggerEndpoint("/swagger/version1/swagger.json", "VSC Solution API");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}