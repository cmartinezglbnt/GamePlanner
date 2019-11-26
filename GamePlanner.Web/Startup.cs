using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamePlanner.Web.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GamePlanner.Web
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
            services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<SeedDb>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<IPublicRepository, PublicRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IIdeaRepository, IdeaRepository>();
            services.AddScoped<IMeetingRepository, MeetingRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IConceptRepository, ConceptRepository>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IGamePlayRepository, GamePlayRepository>();
            services.AddScoped<IPlatformRepository, PlatformRepository>();
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IConceptRepository, ConceptRepository>();
            services.AddScoped<IToolRepository, ToolRepository>();

            services.AddControllersWithViews();
            services.AddRazorPages();
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
