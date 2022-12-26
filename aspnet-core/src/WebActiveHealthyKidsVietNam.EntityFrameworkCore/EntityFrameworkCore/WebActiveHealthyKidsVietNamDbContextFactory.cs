using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WebActiveHealthyKidsVietNam.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class WebActiveHealthyKidsVietNamDbContextFactory : IDesignTimeDbContextFactory<WebActiveHealthyKidsVietNamDbContext>
{
    public WebActiveHealthyKidsVietNamDbContext CreateDbContext(string[] args)
    {
        WebActiveHealthyKidsVietNamEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<WebActiveHealthyKidsVietNamDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new WebActiveHealthyKidsVietNamDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebActiveHealthyKidsVietNam.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
