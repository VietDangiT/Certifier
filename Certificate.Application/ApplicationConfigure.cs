using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Certificate.Application
{
    public static class ApplicationConfigure
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
            //asad
        }
    }
}
