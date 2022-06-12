namespace WebAPI
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebAPIServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddControllers();

            return services;
        }
    }
}
