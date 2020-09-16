using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WampBlazor.Shared.Services;
using WampSharp.V2;

namespace WampBlazor.Server
{
    public class WampMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<WampMiddleware> _logger;

        public WampMiddleware(RequestDelegate next, ILogger<WampMiddleware> logger, IWampHost host, IServiceProvider provider)
        {
            _next = next;
            _logger = logger;

            var realm = host.RealmContainer.GetRealmByName("realm1");
            realm.Services.RegisterCallee(() => provider.CreateScope().ServiceProvider.GetRequiredService<IWeatherForecastService>());
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("WAMP Middleware");
            await _next(httpContext);
        }
    }
}
