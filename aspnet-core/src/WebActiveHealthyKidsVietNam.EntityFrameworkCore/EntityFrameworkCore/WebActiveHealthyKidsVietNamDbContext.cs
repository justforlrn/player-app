using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using WebActiveHealthyKidsVietNam.AboutUss;
using WebActiveHealthyKidsVietNam.EnquirieForms;
using WebActiveHealthyKidsVietNam.Informations;
using WebActiveHealthyKidsVietNam.ModuleHomes;
using WebActiveHealthyKidsVietNam.Modules;
using WebActiveHealthyKidsVietNam.Reports;
using WebActiveHealthyKidsVietNam.SlideLists;

namespace WebActiveHealthyKidsVietNam.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class WebActiveHealthyKidsVietNamDbContext :
    AbpDbContext<WebActiveHealthyKidsVietNamDbContext>,
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

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    // entity core
    public DbSet<Module> Modules { get; set; }
    public DbSet<ModuleHome> ModuleHomes { get; set; }
    public DbSet<AboutUs> AboutUss { get; set; }
    public DbSet<EnquirieForm> EnquirieForms { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<SlideList> SlideLists { get; set; }
    public DbSet<Information> Informations { get; set; }

    #endregion

    public WebActiveHealthyKidsVietNamDbContext(DbContextOptions<WebActiveHealthyKidsVietNamDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(WebActiveHealthyKidsVietNamConsts.DbTablePrefix + "YourEntities", WebActiveHealthyKidsVietNamConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        builder.Entity<Module>(b =>
        {
            b.ToTable(WebActiveHealthyKidsVietNamConsts.DbTablePrefix + "Modules", WebActiveHealthyKidsVietNamConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            //b.HasOne(x=>x.Informations).WithOne(x=>x.Modules).HasForeignKey<Information>(x => x.Id).IsRequired(); 
        });

        builder.Entity<ModuleHome>(b =>
        {
            b.ToTable(WebActiveHealthyKidsVietNamConsts.DbTablePrefix + "ModuleHomes", WebActiveHealthyKidsVietNamConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.HasOne<Module>().WithMany().HasForeignKey(x => x.ModuleId).IsRequired();

        });

        builder.Entity<AboutUs>(b =>
        {
            b.ToTable(WebActiveHealthyKidsVietNamConsts.DbTablePrefix + "AboutUss", WebActiveHealthyKidsVietNamConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
        });

        builder.Entity<EnquirieForm>(b =>
        {
            b.ToTable(WebActiveHealthyKidsVietNamConsts.DbTablePrefix + "EnquirieForms", WebActiveHealthyKidsVietNamConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
        });

        builder.Entity<Report>(b =>
        {
            b.ToTable(WebActiveHealthyKidsVietNamConsts.DbTablePrefix + "Reports", WebActiveHealthyKidsVietNamConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            //b.Property(x => x.KeyFindings).HasNoKey();
        });

        builder.Entity<SlideList>(b =>
        {
            b.ToTable(WebActiveHealthyKidsVietNamConsts.DbTablePrefix + "SlideLists", WebActiveHealthyKidsVietNamConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.HasOne<Module>().WithMany().HasForeignKey(x => x.ModuleId).IsRequired();
        });

        builder.Entity<Information>(b =>
        {
            b.ToTable(WebActiveHealthyKidsVietNamConsts.DbTablePrefix + "Informations", WebActiveHealthyKidsVietNamConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.HasOne<Module>().WithMany().HasForeignKey(x => x.ModuleId).IsRequired();
        });
    }
}
