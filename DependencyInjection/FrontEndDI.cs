namespace GameAppWebAPI.DependencyInjection
{
    using GameAppWebAPI.Services;
    using GameAppWebAPI.Services.IServices;

    public static class FrontEndDI
    {
        public static void AddFrontEndDI(this IServiceCollection services)
        {
            services.AddScoped<IGameService,GameService>();
        }
    }
}
