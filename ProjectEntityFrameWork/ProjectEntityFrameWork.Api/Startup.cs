using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjectEntityFrameWork.Common;
using ProjectEntityFrameWork.Membership;
using ProjectEntityFrameWork.Membership.BusinessObjects;
using ProjectEntityFrameWork.Membership.Contexts;
using ProjectEntityFrameWork.Membership.Entities;
using ProjectEntityFrameWork.Membership.Services;
using ProjectEntityFrameWork.Training;
using ProjectEntityFrameWork.Training.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEntityFrameWork.Api
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

            // This method gets called by the runtime. Use this method to add services to the container.
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


            services.AddAuthentication()  // Microsoft.AspNetCore.Authentication.jwtbearer ei package lagbee // jwt r jonno ekta appsettings e config kora lagbe.. 
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Jwt:Key"])),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"]
                    };
                });



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
                    policy.RequireClaim("view_permission", "true");
                });

                options.AddPolicy("ViewPermission", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.Requirements.Add(new ApiRequirement());
                });
            });

            services.AddSingleton<IAuthorizationHandler, ApiRequirementHandler>(); // claim based er jonno ekhane 

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //automapper config er jonno must 
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectEntityFrameWork.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectEntityFrameWork.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            //main proj er configuration lagbee  
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
