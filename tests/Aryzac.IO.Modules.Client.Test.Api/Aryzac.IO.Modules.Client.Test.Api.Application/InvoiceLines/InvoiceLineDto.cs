using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Mappings;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Entities;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines
{
    public class InvoiceLineDto : IMapFrom<InvoiceLine>
    {
        public InvoiceLineDto()
        {
        }

        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

        public static InvoiceLineDto Create(
            Guid id,
            Guid invoiceId,
            Guid productId,
            decimal quantity,
            decimal unitPrice,
            decimal discount)
        {
            return new InvoiceLineDto
            {
                Id = id,
                InvoiceId = invoiceId,
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = unitPrice,
                Discount = discount
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<InvoiceLine, InvoiceLineDto>();
        }
    }
}