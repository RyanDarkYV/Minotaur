using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Minotaur.CommonParts.Redis
{
    public static class Extensions
    {
        private static readonly string SectionName = "redis";

        public static IServiceCollection AddRedis(this IServiceCollection services)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            services.Configure<RedisOptions>(configuration.GetSection(SectionName));
            var options = configuration.GetOptions<RedisOptions>(SectionName);
            services.AddDistributedRedisCache(r =>
            {
                r.Configuration = options.ConnectionString;
                r.InstanceName = options.Instance;
            });

            return services;
        }
    }
}