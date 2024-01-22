using Intent.RoslynWeaver.Attributes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.AspNetCore.SignalR.SignalRConfiguration", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Api.Configuration
{
    public static class SignalRConfiguration
    {
        public static IServiceCollection ConfigureSignalR(this IServiceCollection services)
        {
            services.AddSignalR();
            services.RegisterServices();
            return services;
        }

        public static void RegisterServices(this IServiceCollection services)
        {
        }

        public static IEndpointRouteBuilder MapHubs(this IEndpointRouteBuilder endpoints)
        {
            return endpoints;
        }
    }
}