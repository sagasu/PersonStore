using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PersonStore.Services.Data.Model;
using PersonStore.Services.DTO;

namespace PersonStore.Services.Config
{
    public static class AutomapperConfig
    {
        public static void Configure(IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(cfg => 
                cfg.CreateMap<PersonDTO, Person>()
            );
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
