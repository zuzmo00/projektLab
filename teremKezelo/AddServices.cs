using AutoMapper;
using teremKezelo.Services;

namespace teremKezelo
{
    public class AddServices
    {
        public static void AddServicesToContainer(IServiceCollection services)
        {
            services.AddScoped<ILocationService, LocationService>();
            services.AddAutoMapper(config => config.AddProfile<AutoMapperProfile>());
            services.AddScoped<IResourceService, ResourceService>();
        }
    }
}