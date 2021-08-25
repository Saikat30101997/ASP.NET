using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ProjectEntityFrameWork.Training;
using ProjectEntityFrameWork.Training.Contexts;
using ProjectEntityFrameWork.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectEntityFrameWork.Membership.Contexts;
using ProjectEntityFrameWork.Membership.Entities;
using ProjectEntityFrameWork.Membership;
using ProjectEntityFrameWork.Membership.Services;
using Microsoft.AspNetCore.Authorization;
using ProjectEntityFrameWork.Membership.BusinessObjects;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProjectEntityFrameWork
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            WebHostEnvironment = env;

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }
        public static ILifetimeScope AutofacContainer { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var connectionInfo = GetConnectionStringAndAssemblyName();

            builder.RegisterModule(new TrainingModule(connectionInfo.connectionString,
                connectionInfo.migrationAssemblyName));
            builder.RegisterModule(new CommonModule());
            builder.RegisterModule(new WebModule());
            builder.RegisterModule(new MembershipModule(connectionInfo.connectionString, 
                connectionInfo.migrationAssemblyName));
        }

        private (string connectionString, string migrationAssemblyName) GetConnectionStringAndAssemblyName()
        {
            var connectionStringName = "DefaultConnection";
            var connectionString = Configuration.GetConnectionString(connectionStringName);
            var migrationAssemblyName = typeof(Startup).Assembly.FullName;
            return (connectionString, migrationAssemblyName);
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionInfo = GetConnectionStringAndAssemblyName();

            services.AddDbContext<ApplicationDbContext>(options => // applicationdbcontext jodi alada project e thake tahole seta k migration er maddhome add korar jonno
                options.UseSqlServer(connectionInfo.connectionString, b =>
                b.MigrationsAssembly(connectionInfo.migrationAssemblyName)));

            services.AddDbContext<TrainingContext>(options =>
                options.UseSqlServer(connectionInfo.connectionString, b =>
                b.MigrationsAssembly(connectionInfo.migrationAssemblyName)));

            services  // service class gula k customize korte pari shey jonno egula k alada kore customize korar jonno use kora hy
                  .AddIdentity<ApplicationUser, Role>()
                  .AddEntityFrameworkStores<ApplicationDbContext>()
                  .AddUserManager<UserManager>() //userM,RolM,SighnM egula service class
                  .AddRoleManager<RoleManager>()
                  .AddSignInManager<SignInManager>()
                  .AddDefaultUI()
                  .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options => //password config er jonno 
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });
            //ei pura jinis ta lagbe amr jokhn web api r concept main project e anii

            services.AddAuthentication()  // Microsoft.AspNetCore.Authentication.jwtbearer ei package lagbee // jwt r jonno ekta appsettings e config kora lagbe.. 
                  .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                  {
                      options.LoginPath = new PathString("/Account/Login");
                      options.AccessDeniedPath = new PathString("/Account/Login");
                      options.LogoutPath = new PathString("/Account/Logout");
                      options.Cookie.Name = "CustomerPortal.Identity";
                      options.SlidingExpiration = true;
                      options.ExpireTimeSpan = TimeSpan.FromDays(1);
                  })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
                {
                x.RequireHttpsMetadata = false; //https lagbe kinaa 
                    x.SaveToken = true; //token save koraa
                    x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, //issuer korbe kinaa
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Jwt:Key"])), //encrypted korbe issuer key ta diyee
                        ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"]
                };
            });
            //ei cookie setting ta r lagbe na karon cookie ta jwt r sate add koree disi jodi jwt config na kori tahole nicher ta lagbee 
            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

            //    options.LoginPath = "/Account/Signin";
            //    options.AccessDeniedPath = "/Account/AccessDenied";
            //    options.SlidingExpiration = true;
            //});

            //by default shb gula uthentication scheme cookie r ta use korbe bt jodi prblm hy bydefault e tahole
            //policy.AuthenticationSchemes.Add(CookieAuthenticationDefaults.AuthenticationScheme);
            //evabe add korte hobe

            services.AddAuthorization(options =>  //policy and claim er jonno use kora hy 
            {
                options.AddPolicy("AdminandTeacherAccess", policy =>
                {
                    policy.RequireAuthenticatedUser();
                
                    policy.RequireRole("Teacher");
                    policy.RequireRole("Admin");
                  
                });

                options.AddPolicy("RestrictedArea", policy =>
                {
                    policy.RequireAuthenticatedUser();
                  
                    policy.RequireClaim("view_permission","true");
                });

                options.AddPolicy("ViewPermission", policy =>
                {
                    policy.RequireAuthenticatedUser();
           
                    policy.Requirements.Add(new ViewRequirement());
                });

                options.AddPolicy("AccessPermission", policy =>
                {
                    policy.AuthenticationSchemes.Clear();
                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                    policy.Requirements.Add(new ApiRequirement());
                });
            });

            services.AddSingleton<IAuthorizationHandler, ViewRequirementHandler>(); // claim based er jonno ekhane 
            services.AddSingleton<IAuthorizationHandler, ApiRequirementHandler>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //automapper config er jonno must 
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddRazorPages();
            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
