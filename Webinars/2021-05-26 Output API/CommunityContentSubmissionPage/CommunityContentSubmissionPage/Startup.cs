using CommunityContentSubmissionPage.Business.Logic;
using CommunityContentSubmissionPage.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using System;

namespace CommunityContentSubmissionPage
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
            services.AddControllersWithViews();

            services.AddScoped<IDatabaseContext, DatabaseContext>();
            services.AddScoped<ISubmissionSaver, SubmissionSaver>();

            services.AddHealthChecks();
            services.AddDbContext<DatabaseContext>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapHealthChecks("/health");
            });

            var policy = Policy.Handle<Exception>().WaitAndRetry(10, i => TimeSpan.FromSeconds(10));

            policy.Execute(() => EnsureDB(app));
        }

        private static void EnsureDB(IApplicationBuilder app)
        {
            var databaseContext = new DatabaseContext();
            databaseContext.Database.EnsureCreated();
        }
    }
}
