using Acme.EcommerceSystem.UserAccounts;
using Acme.EcommerceSystem.UserProfiles;
using Acme.EcommerceSystem.UserTransactions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Acme.EcommerceSystem.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class EcommerceSystemDbContext :
    AbpDbContext<EcommerceSystemDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    public DbSet<UserProfile> UserProfiles { get; set; }

    public DbSet<UserAccount> UserAccounts { get; set; }

    public DbSet<UserTransaction> UserTransactions { get; set; }   

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public EcommerceSystemDbContext(DbContextOptions<EcommerceSystemDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(EcommerceSystemConsts.DbTablePrefix + "YourEntities", EcommerceSystemConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<UserProfile>(b =>
        {
            b.ToTable(EcommerceSystemConsts.DbTablePrefix + "UserProfiles", EcommerceSystemConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props

            b.Property(x => x.Name).IsRequired().HasMaxLength(100);
            b.Property(x => x.Age).IsRequired().HasMaxLength(3);
            b.Property(x => x.Address).IsRequired().HasMaxLength(100);

            b.HasIndex(x => x.Name).IsUnique();


        });

        builder.Entity<UserAccount>(b =>
        {
            b.ToTable(EcommerceSystemConsts.DbTablePrefix + "UserAccounts", EcommerceSystemConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props

                b.Property(x => x.BankName).IsRequired().HasMaxLength(100);
            b.Property(x => x.ActNumber).IsRequired().HasMaxLength(18);
            b.Property(x => x.UserName).IsRequired().HasMaxLength(100);

            b.HasOne(b => b.UserAccount).WithMany(a => a.UserProfile).HasForeignKey(z => z.UserID).IsRequired();
            b.HasOne(b => b.UserAccount).WithMany(a => a.UserTransaction).HasForeignKey(z => z.UserTransactionID).IsRequired();
        });

        builder.Entity<UserTransaction>(b =>
        {
            b.ToTable(EcommerceSystemConsts.DbTablePrefix + "UserTransactions", EcommerceSystemConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            //b.HasOne(b => b.UserProfile).WithMany(a => a.UserAccounts).HasForeignKey(z => z.UserID).IsRequired();

        });
    }
}
