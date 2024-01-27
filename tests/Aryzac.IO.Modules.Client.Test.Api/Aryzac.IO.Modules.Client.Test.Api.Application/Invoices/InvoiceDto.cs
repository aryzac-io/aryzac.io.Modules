using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Mappings;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Entities;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Invoices
{
    public class InvoiceDto : IMapFrom<Invoice>
    {
        public InvoiceDto()
        {
            Number = null!;
        }

        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string Number { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset DueDate { get; set; }

        public static InvoiceDto Create(
            Guid id,
            Guid clientId,
            string number,
            DateTimeOffset createdDate,
            DateTimeOffset dueDate)
        {
            return new InvoiceDto
            {
                Id = id,
                ClientId = clientId,
                Number = number,
                CreatedDate = createdDate,
                DueDate = dueDate
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Invoice, InvoiceDto>();
        }
    }
}