using Certificate.Domain.IRepositories;
using Certificate.Domain.IServices;
using Certificate.Infrastructure.Repositories;
using Certificate.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Certificate.Infrastructure
{
    public static class InfrastructureConfigure
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ICertificateService, CertificateService>();
            services.AddScoped<ICertificateRepository, CertificateRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            return services;
        }
    }
}
