namespace GameAppWebAPI.DependencyInjection
{
    public static class SpecialConnectorsDI
    {
        public static void AddSpecialConnectorDI(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
