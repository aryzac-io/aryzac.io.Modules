using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Common;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Common.Interfaces;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Entities;
using Aryzac.IO.Modules.Client.Test.Api.Infrastructure.Persistence.Configurations;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.DbContext", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly IDomainEventService _domainEventService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventService domainEventService) : base(options)
        {
            _domainEventService = domainEventService;
        }

        public DbSet<Api.Domain.Entities.Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<Title> Titles { get; set; }

        public override async Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            await DispatchEventsAsync(cancellationToken);
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            DispatchEventsAsync().GetAwaiter().GetResult();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureModel(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceLineConfiguration());
            modelBuilder.ApplyConfiguration(new TitleConfiguration());
        }

        [IntentManaged(Mode.Ignore)]
        private void ConfigureModel(ModelBuilder modelBuilder)
        {
            // Seed data
            // https://rehansaeed.com/migrating-to-entity-framework-core-seed-data/
            /* Eg.
            
            modelBuilder.Entity<Car>().HasData(
            new Car() { CarId = 1, Make = "Ferrari", Model = "F40" },
            new Car() { CarId = 2, Make = "Ferrari", Model = "F50" },
            new Car() { CarId = 3, Make = "Lamborghini", Model = "Countach" });
            */
        }

        /// <summary>
        /// Calling EnsureCreatedAsync is necessary to create the required containers and insert the seed data if present in the model. 
        /// However EnsureCreatedAsync should only be called during deployment, not normal operation, as it may cause performance issues.
        /// </summary>
        public async Task EnsureDbCreatedAsync()
        {
            await Database.EnsureCreatedAsync();
        }

        private async Task DispatchEventsAsync(CancellationToken cancellationToken = default)
        {
            while (true)
            {
                var domainEventEntity = ChangeTracker
                    .Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .FirstOrDefault(domainEvent => !domainEvent.IsPublished);

                if (domainEventEntity is null)
                {
                    break;
                }

                domainEventEntity.IsPublished = true;
                await _domainEventService.Publish(domainEventEntity, cancellationToken);
            }
        }
    }
}