using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;
using HRSolution.Infrastructure.Extension;
using HRSolution.Service;
using HRSolution.Data;
using Microsoft.EntityFrameworkCore;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace HRSolution.Server
{
    public class Startup
    {
        private readonly IConfigurationRoot configRoot;
        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;

            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configRoot = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext(Configuration, configRoot);

            services.AddAutoMapper();

            services.AddScopedServices();

            services.AddTransientServices();

            services.AddSwaggerOpenAPI();

            services.AddMailSetting(Configuration);

            services.AddMediatorCQRS();

            services.AddVersion();

            services.AddFluentMigratorCore().ConfigureRunner(builder => builder.AddSqlServer()
                                            .WithGlobalConnectionString(Configuration.GetConnectionString("HrSolutionConn"))
                                            .ScanIn(typeof(CreateTableOperation).Assembly).For.Migrations());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log, IMigrationRunner migrationRunner)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.ConfigureCustomExceptionMiddleware();

            app.ConfigureSwagger();

            log.AddSerilog();

            InitializeDatabase(app, migrationRunner);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InitializeDatabase(IApplicationBuilder app, IMigrationRunner migrationRunner)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
            }
            migrationRunner.MigrateUp();
        }
    }
}

