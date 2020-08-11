namespace DataForSeo.BLL.Extensions
{
    using DataForSeo.BLL.Interfaces;
    using DataForSeo.BLL.Services;
    using DataForSeo.DAL.EF;
    using DataForSeo.DAL.Interfaces;
    using DataForSeo.DAL.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddTransient<IDataRepository, DataRepository>()
                .AddTransient<IDataService, DataService>()
                .AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
