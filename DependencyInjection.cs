using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldTour.Common.Behaviors;
using WorldTour.Common.Files;
using WorldTour.Common.Helpers;
using WorldTour.Common.Interfaces;
using WorldTour.Common.Mappings;
using WorldTour.Common.Services;
using WorldTour.Common.Settings;
using WorldTour.Data;

namespace WorldTour;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // services.AddAutoMapper(c => c.AddProfile(new MappingProfile()));
        // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        // services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));

        return services;
    }

    public static IServiceCollection AddInfrastructureShared(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<MailSettings>(config.GetSection("MailSettings"));
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

        return services;
    }

    public static IServiceCollection AddInfrastructureData(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlite("DataSource=TourDatabase.sqlite3")
        );
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        return services;
    }

    public static IServiceCollection AddInfrastructureIdentity(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<AuthSettings>(config.GetSection(nameof(AuthSettings)));
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}