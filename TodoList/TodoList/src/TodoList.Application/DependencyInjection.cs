using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace TodoList.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AppApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
