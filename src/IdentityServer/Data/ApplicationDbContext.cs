using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityServer.Models;
using Microsoft.EntityFrameworkCore.Design;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;

namespace IdentityServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

    public class ConfigurationDbContextFactory : IDesignTimeDbContextFactory<ConfigurationDbContext>
    {
        public ConfigurationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConfigurationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost,1436;database=OnlineShop.IdentityServer; Persist Security Info=True;User ID=sa;Password=Kos_540232;");

            var configurationStoreOptions = new ConfigurationStoreOptions();

            return new ConfigurationDbContext(optionsBuilder.Options, configurationStoreOptions);
        }
    }

    public class PersistedGrantDbContextFactory : IDesignTimeDbContextFactory<PersistedGrantDbContext>
    {
        public PersistedGrantDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PersistedGrantDbContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost,1436;database=OnlineShop.IdentityServer; Persist Security Info=True;User ID=sa;Password=Kos_540232;");

            var operationalStoreOptions = new OperationalStoreOptions();

            return new PersistedGrantDbContext(optionsBuilder.Options, operationalStoreOptions);
        }
    }
}
