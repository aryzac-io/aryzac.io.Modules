using System.Collections.Generic;
using System.Linq;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Entities;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines
{
    public static class InvoiceLineDtoMappingExtensions
    {
        public static InvoiceLineDto MapToInvoiceLineDto(this InvoiceLine projectFrom, IMapper mapper)
            => mapper.Map<InvoiceLineDto>(projectFrom);

        public static List<InvoiceLineDto> MapToInvoiceLineDtoList(this IEnumerable<InvoiceLine> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToInvoiceLineDto(mapper)).ToList();
    }
}