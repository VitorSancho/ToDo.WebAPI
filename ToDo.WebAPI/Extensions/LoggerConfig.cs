using Elmah.Io.Extensions.Logging;

namespace ToDo.WebAPI.Extensions
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "f9e07c1d34cc410781b85fabd395a86f";
                o.LogId = new Guid("8280a404-d053-417d-adf1-049b8a417de1");
            });

            services.AddLogging(builder =>
            {
                builder.AddElmahIo(o =>
                {
                    o.ApiKey = "f9e07c1d34cc410781b85fabd395a86f";
                    o.LogId = new Guid("8280a404-d053-417d-adf1-049b8a417de1");
                });
            }
                );

            return services;
        }
        public static IApplicationBuilder UseLoggingConfigutration(this IApplicationBuilder app)
        {
            app.UseElmahIo();
            return app;
        }
    }
}
