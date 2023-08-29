using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Library.UserManagmentService.Models;

namespace OnlineShop.Library.Data
{
    public class UsersDbContext : IdentityDbContext<ApplicationUser>
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options)
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

    /*public class ConfigurationDbContextFactory : IDesignTimeDbContextFactory<ConfigurationDbContext>
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
    }*/
}
