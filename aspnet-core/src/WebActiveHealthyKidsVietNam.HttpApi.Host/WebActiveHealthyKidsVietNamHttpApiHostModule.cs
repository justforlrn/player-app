using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebActiveHealthyKidsVietNam.EntityFrameworkCore;
using WebActiveHealthyKidsVietNam.MultiTenancy;
using StackExchange.Redis;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.DistributedLocking;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.VirtualFileSystem;
using WebActiveHealthyKidsVietNam.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebActiveHealthyKidsVietNam;

[DependsOn(
    typeof(WebActiveHealthyKidsVietNamHttpApiModule),
    typeof(AbpAutofacModule),
    //typeof(AbpCachingStackExchangeRedisModule),
    //typeof(AbpDistributedLockingModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(WebActiveHealthyKidsVietNamApplicationModule),
    typeof(WebActiveHealthyKidsVietNamEntityFrameworkCoreModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule)
)]
public class WebActiveHealthyKidsVietNamHttpApiHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        ConfigureConventionalControllers();
        ConfigureAuthentication(context, configuration);
        ConfigureLocalization();
        //ConfigureCache(configuration);
        ConfigureVirtualFileSystem(context);
        //ConfigureDataProtection(context, configuration, hostingEnvironment);
        //ConfigureDistributedLocking(context, configuration);
        ConfigureCors(context, configuration);
        ConfigureSwaggerServices(context, configuration);
        
    }

    private void ConfigureCache(IConfiguration configuration)
    {
        Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "WebActiveHealthyKidsVietNam:"; });
    }

    private void ConfigureVirtualFileSystem(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<WebActiveHealthyKidsVietNamDomainSharedModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}WebActiveHealthyKidsVietNam.Domain.Shared"));
                options.FileSets.ReplaceEmbeddedByPhysical<WebActiveHealthyKidsVietNamDomainModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}WebActiveHealthyKidsVietNam.Domain"));
                options.FileSets.ReplaceEmbeddedByPhysical<WebActiveHealthyKidsVietNamApplicationContractsModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}WebActiveHealthyKidsVietNam.Application.Contracts"));
                options.FileSets.ReplaceEmbeddedByPhysical<WebActiveHealthyKidsVietNamApplicationModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}WebActiveHealthyKidsVietNam.Application"));
            });
        }
    }

    private void ConfigureConventionalControllers()
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(WebActiveHealthyKidsVietNamApplicationModule).Assembly);
        });
    }

    private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(nameof(JwtSettings), jwtSettings);

        var tokenValidationParamaters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidateLifetime = false

        };
        context.Services.AddSingleton(tokenValidationParamaters);
        context.Services.AddSingleton(jwtSettings);
        context.Services.AddAuthentication("Bearer")
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = tokenValidationParamaters;
        });
    }

    private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddSwaggerGen(options =>
        {

            var apiSecurity = new OpenApiSecurityRequirement{
                          {
                             new OpenApiSecurityScheme{
                                 Reference = new OpenApiReference{
                                 Id = "Bearer", //The name of the previously defined security scheme.
                                 Type = ReferenceType.SecurityScheme
                            }
                          },new List<string>()  }};
            options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the bearer scheme",
                Name = "Authorization",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(apiSecurity);

            options.SwaggerDoc("v1", new OpenApiInfo { Title = "WebActiveHealthyKidsVietNam API", Version = "v1" });
            options.DocInclusionPredicate((docName, description) => true);
            var applicationApisXml = Path.Combine(AppContext.BaseDirectory, "WebActiveHealthyKidsVietNam.HttpApi.xml");
            options.IncludeXmlComments(applicationApisXml);

            var applicationContractsXml = Path.Combine(AppContext.BaseDirectory, "WebActiveHealthyKidsVietNam.Application.Contracts.xml");
            options.IncludeXmlComments(applicationContractsXml);

            var applicationShareXml = Path.Combine(AppContext.BaseDirectory, "WebActiveHealthyKidsVietNam.Domain.Shared.xml");
            options.IncludeXmlComments(applicationShareXml);
        });
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
            options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
            options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
            options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
            options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
            options.Languages.Add(new LanguageInfo("is", "is", "Icelandic", "is"));
            options.Languages.Add(new LanguageInfo("it", "it", "Italiano", "it"));
            options.Languages.Add(new LanguageInfo("ro-RO", "ro-RO", "Română"));
            options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
            options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
            options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
            options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
            options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch", "de"));
            options.Languages.Add(new LanguageInfo("es", "es", "Español", "es"));
            options.Languages.Add(new LanguageInfo("el", "el", "Ελληνικά"));
        });
    }

    private void ConfigureDataProtection(
        ServiceConfigurationContext context,
        IConfiguration configuration,
        IWebHostEnvironment hostingEnvironment)
    {
        var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("WebActiveHealthyKidsVietNam");
        if (!hostingEnvironment.IsDevelopment())
        {
            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "WebActiveHealthyKidsVietNam-Protection-Keys");
        }
    }
    
    private void ConfigureDistributedLocking(
        ServiceConfigurationContext context,
        IConfiguration configuration)
    {
        context.Services.AddSingleton<IDistributedLockProvider>(sp =>
        {
            var connection = ConnectionMultiplexer
                .Connect(configuration["Redis:Configuration"]);
            return new RedisDistributedSynchronizationProvider(connection.GetDatabase());
        });
    }

    private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.RemovePostFix("/"))
                            .ToArray()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }

        app.UseAuthorization();

        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebActiveHealthyKidsVietNam API");
        });

        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseUnitOfWork();
        app.UseConfiguredEndpoints();
    }
}
