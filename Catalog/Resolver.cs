using Catalog.Services;

namespace Catalog
{
    public class Resolver
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICatalogService, CatalogService>();
        }
    }
}
