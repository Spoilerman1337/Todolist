using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TodoList.Application.Common.Behaviors;
using TodoList.Application.Common.Interfaces;
using TodoList.Application.Common.Mappings;

namespace TodoList.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new MappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new MappingProfile(typeof(ITodoListDbContext).Assembly));
        });
        services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }
}

