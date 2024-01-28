using Aryzac.IO.Modules.Client.Test.Api.Domain.Entities;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Infrastructure.Persistence.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Api.Domain.Entities.Client>
    {
        public void Configure(EntityTypeBuilder<Api.Domain.Entities.Client> builder)
        {
            builder.ToContainer("Aryzac.IO.Modules.Client.Test.Api");

            builder.HasPartitionKey(x => x.Id);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired();

            builder.Property(x => x.LastName)
                .IsRequired();

            builder.Property(x => x.OtherNames);

            builder.Property(x => x.TitleId)
                .IsRequired();

            builder.Property(x => x.ReceivePromotions)
                .IsRequired();

            builder.Property(x => x.Notes)
                .IsRequired();

            builder.Ignore(e => e.DomainEvents);
        }
    }
}