namespace GameAppWebAPI.DependencyInjection
{
    using GameAppWebAPI.Helpers;
    using GameAppWebAPI.Repository;

    public static class DataAccessLayerDI
    {
        public static void AddDataAccessLayerDI(this IServiceCollection services) 
        {
            services.AddDbContext<DataContext>();
            services.AddScoped<IGameRepository, GameRepository>();
        }
    }
}
