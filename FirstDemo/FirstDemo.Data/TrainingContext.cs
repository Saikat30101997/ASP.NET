using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Data
{
    public class TrainingContext:DbContext  // etar Referta diye dite hobe webproj er startup.cs er file ConfigureService method e 
    {
        private readonly string _connectionString; //ConnectionString er jonno
        private readonly string _migrationAssemblyName; //eta lagbe karon WebProject er sate TrainingContext Connected na Connection korar jonno
                                               //eta reference create kore webproject er sathe er reference name lage 

        public TrainingContext(string connectionString,string migrationAssemblyName) //ei duita jinis lagbee connectionstring r assembly refernce
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) //kind of jeta web e ekta connectionstring dwr jonno add korechi amn connectionstring to diyechi sate webproject refer assembly diye disi eta DbContext er ekta method
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }
        public DbSet<Course> Courses { get; set; } // table class Course er sathe TrainingContext Connect korar jonno ..DbContext class er sathe o Course class connect korar jonno 
                                                   //Course class er sathe EntityFrameWork er sathe Connect korche
        public DbSet<Student> Students { get; set; }
    
    }
}
