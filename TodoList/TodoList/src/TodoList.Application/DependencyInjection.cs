using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using TodoList.Application.Common.Interfaces;
using TodoList.Application.Common.Mappings;

namespace TodoList.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(config => { 
                config.AddProfile(new MappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new MappingProfile(typeof(ITodoListDbContext).Assembly));
            });

            return services;
        }
    }
}
