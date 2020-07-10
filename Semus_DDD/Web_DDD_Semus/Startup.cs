using ApplicationApp.Interfaces;
using ApplicationApp.OpenApp;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceEntities;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Identity.Context;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Infrastructure.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Web_DDD_Semus
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
            _ = services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGeneric<>));

            _ = services.AddSingleton<IProduct, RepositoryProduct>();
            _ = services.AddSingleton<IStock, RepositoryStock>();
            _ = services.AddSingleton<IStockProducts, RepositoryStockProducts>();

            _ = services.AddSingleton<IProductApp, AppProduct>();
            _ = services.AddSingleton<IStockApp, AppStock>();
            _ = services.AddSingleton<IStockProductsApp, AppStockProducts>();

            _ = services.AddSingleton<IServiceStock, ServiceStock>();

            _ = services.AddControllersWithViews();
            _ = services.AddDbContext<ContextBase>(
                option => option
                .UseLazyLoadingProxies()
                .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning))
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            _ = services.AddDbContext<ApplicationDbContext>(
                options => options
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            _ = services.AddDefaultIdentity<IdentityUser>(
                options => options
                .SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
                _ = app.UseDatabaseErrorPage();
            }
            else
            {
                _ = app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                _ = app.UseHsts();
            }

            _ = app.UseHttpsRedirection();
            _ = app.UseStaticFiles();
            _ = app.UseRouting();
            _ = app.UseAuthentication();
            _ = app.UseAuthorization();

            _ = app.UseEndpoints(endpoints =>
              {
                  _ = endpoints.MapControllerRoute(
                      name: "default",
                      pattern: "{controller=Home}/{action=Index}/{id?}");
                  _ = endpoints.MapRazorPages();
              });
        }
    }
}
