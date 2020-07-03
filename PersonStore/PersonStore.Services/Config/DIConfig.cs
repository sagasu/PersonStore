using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonStore.Services.Data;
using PersonStore.Services.Services;

namespace PersonStore.Services.Config
{
    public static class DIConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddDbContext<StoreContext>(options =>
                options.UseSqlite("Data Source=store.db"));

            services.AddTransient<IPersonService, PersonService>();
        }
    }
}
