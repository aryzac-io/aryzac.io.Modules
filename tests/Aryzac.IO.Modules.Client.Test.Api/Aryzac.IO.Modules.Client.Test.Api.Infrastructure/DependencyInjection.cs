using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Common.Interfaces;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Repositories;
using Aryzac.IO.Modules.Client.Test.Api.Infrastructure.Configuration;
using Aryzac.IO.Modules.Client.Test.Api.Infrastructure.Persistence;
using Aryzac.IO.Modules.Client.Test.Api.Infrastructure.Repositories;
using Aryzac.IO.Modules.Client.Test.Api.Infrastructure.Services;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Infrastructure.DependencyInjection.DependencyInjection", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseInMemoryDatabase("DefaultConnection");
                options.UseLazyLoadingProxies();
            });
            services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddTransient<IInvoiceLineRepository, InvoiceLineRepository>();
            services.AddTransient<ITitleRepository, TitleRepository>();
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddMassTransitConfiguration(configuration);
            services.AddHttpClients(configuration);
            return services;
        }
    }
}