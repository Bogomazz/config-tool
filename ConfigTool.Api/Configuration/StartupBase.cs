using System.Reflection;
using System.Threading.Tasks;
using ConfigTool.Domain.Contract;
using ConfigTool.Infrastructure;
using ConfigTool.Infrastructure.Repositories;
using log4net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigTool.Api.Configuration
{
    public abstract class CommonStartup
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected IConfiguration Configuration { get; }

        protected CommonStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddWebApi()
                .AddControllers()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<IChlenRepository, ChlenRepository>();

            services.AddSingleton(AutoMapperConfig.Configure());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Logger.Info("Application starting...");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            Task.Run(() => ConfigureDbAsync(app));
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseCors(Configuration);
            app.UseMvcWithDefaultRoute();
            
            Logger.Info("Application is started");
        }

        protected virtual async Task ConfigureDbAsync(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();
                if (!await context.Database.EnsureCreatedAsync())
                {
                    await context.Database.MigrateAsync();
                }
            }
        }
    }
}