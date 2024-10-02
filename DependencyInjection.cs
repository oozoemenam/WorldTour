﻿using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldTour.Common.Behaviors;
using WorldTour.Common.Files;
using WorldTour.Common.Interfaces;
using WorldTour.Common.Services;
using WorldTour.Common.Settings;
using WorldTour.Data;

namespace WorldTour;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        // services.AddMediatR(Assembly.GetExecutingAssembly());
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
}