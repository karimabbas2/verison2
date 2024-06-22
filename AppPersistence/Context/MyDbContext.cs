using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDomain;
using AppDomain.Concrets;
using AppDomain.TrunkEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AppPersistence.Context
{
    public class MyDbContext(IConfiguration configuration) : IdentityDbContext
    {
        private readonly IConfiguration _configuration = configuration;

        static readonly string connectionString = "Server=localhost; User ID=root; Password=123456Aa*; Database=FIBERME_TEST;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseMySql(_configuration.GetConnectionString("myConn"),
            //  b => b.MigrationsAssembly("Server"));

            optionsBuilder.UseMySql(_configuration.GetConnectionString("myConn"),
            ServerVersion.AutoDetect(_configuration.GetConnectionString("myConn")),
            x => x.MigrationsAssembly("Server"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Seeding
            SeedData.SeedData.Build(builder).Seed();

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Extenstion> Extenstions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Codec> Codecs { get; set; }
        public DbSet<DestRoute> DestRoutes { get; set; }
        public DbSet<DTMF> DTMFs { get; set; }
        public DbSet<JitterBuffer> JitterBuffers { get; set; }
        public DbSet<Privilege> Call_Privileges { get; set; }
        public DbSet<TimeGroups> TimeGroups { get; set; }
        public DbSet<GlobalExtenstionDefault> GlobalExtenstionDefaults { get; set; }
        public DbSet<Trunk> Trunks { get; set; }
        public DbSet<SIPSetting> SIPSettings { get; set; }
        public DbSet<VoicePrompts> VoicePrompts { get; set; }

    }

}