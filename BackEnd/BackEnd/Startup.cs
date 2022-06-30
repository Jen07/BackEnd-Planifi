using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;
using BackEnd.Models;
using BackEnd.Services;



namespace BackEnd
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
            services.Configure<UserSettings>
               (Configuration.GetSection(nameof(UserSettings)));

            services.AddSingleton<IUserSettings>(
                d => d.GetRequiredService<IOptions<UserSettings>>().Value);


            services.Configure<ConfigurationSetting>
            (Configuration.GetSection(nameof(ConfigurationSetting)));

            services.AddSingleton<IConfigurationSetting>(
                d => d.GetRequiredService<IOptions<ConfigurationSetting>>().Value);

            services.Configure<MemPoolSettings>
            (Configuration.GetSection(nameof(MemPoolSettings)));

            services.AddSingleton<IMemPoolSettings>(
                d => d.GetRequiredService<IOptions<MemPoolSettings>>().Value);


           services.Configure<BlockSettings>
            (Configuration.GetSection(nameof(BlockSettings)));

            services.AddSingleton<IBlockSettings>(
                d => d.GetRequiredService<IOptions<BlockSettings>>().Value);


            services.AddControllers();
            
            services.AddSingleton<UserService>();

            services.AddSingleton<ConfigurationService>();

            services.AddSingleton<MemPoolService>();

            services.AddSingleton<BlockService>();

            services.AddCors(Options =>
            {
                Options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
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

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
