﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectEntityFrameWork.Membership.Entities;
using ProjectEntityFrameWork.Membership.Seeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEntityFrameWork.Membership.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,Role,Guid,UserClaim,
        UserRole,UserLogin,RoleClaim,UserToken>,IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ApplicationDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {
            
            modelBuilder.Entity<Role>()
                .HasData(DataSeed.Roles);   //seeding apply data initialization er jonno dataseeding use koraa hy 

            base.OnModelCreating(modelBuilder);
        }
    }
}
