using FirstDemo.Data;
using FirstDemo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using FirstDemo.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Autofac;

namespace FirstDemo
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        // ekhane j constructor er mddhe j kaj ta korchi tar bodolee ami use korboo new ekta configuration
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder() // ConfigurationBuilder er object create korlam
                         .SetBasePath(env.ContentRootPath) //appsettings.json file er path ta basepath e set kore dicche
                         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) // appsettings.json file ta set korche ..amdr onno nam e json file name dile sekhane file name ta diye dilei hobe
                         .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true) //appsettings.json file er sate environment file k add korchee merge korchee
                         .AddEnvironmentVariables(); //environment variable add korchee


                          WebHostEnvironment = env; // WebHostEnvironment property jeta nisi er mddhe env set kore dicchi
                          Configuration = builder.Build(); //Configuration Property r mddhe builder ekta kaj korchi seta Build kore set kore dicchi
        }
        
         public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public static ILifetimeScope AutofacContainer { get; set; } // j property likhar kothaa setaa likhaa ta ekhane likhbo
                                                                    // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new WebModule()); //ullhek kore dilam
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            //seession er jonno etaa lagbe asp.net e cookie bole configuration ache setar settings
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Signin";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(100); //session kotosec pore timeout korbee
                options.Cookie.HttpOnly = true; // cookie http te nibe naki naa 
                options.Cookie.IsEssential = true;
            });

            services.AddTransient<IDataDriver, LocalDriver>(); // amra jodi kokhno DI project e korte chai tahole built in DI korbo tahole asp.net er built in use korte parboo.. tobe eta asp.net er built in amra mainly kaj ta korbo autofac diye jeta third party lib


            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
      
            services.Configure<SmtpConfiguration>(Configuration.GetSection("Smtp")); // eta diye smtp section configure korlam. obossoi smtpConfiguration class create korte hobe..
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddRazorPages();
            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot(); //autofac er jonno eta likhte hobe tobe ekta property likhte hobe
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
         );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
