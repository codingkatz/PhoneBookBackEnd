using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using phonebookCollectionService.Repositories;
using phonebookCollectionService.Repositories.Interfaces;
using phonebookCollectionService.Services;
using phonebookCollectionService.SQL;
using phonebookCollectionService.SQL.Interfaces;

namespace phonebookCollectionService
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

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var options = configuration.GetOptions<SQLOptions>("sql");

                services.AddSingleton(typeof(ISQLOptions), options);
            }

            //Providers
            services.AddTransient<IConnectionManager, ConnectionManager>();
            services.AddTransient<IStorageProvider<SQLStorage>, SQLStorage>();


            //Services
            services.AddSingleton<IEntriesService, EntriesService>();

            //Repositories
            services.AddSingleton<IEntriesRepository, EntriesRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
    }
}
