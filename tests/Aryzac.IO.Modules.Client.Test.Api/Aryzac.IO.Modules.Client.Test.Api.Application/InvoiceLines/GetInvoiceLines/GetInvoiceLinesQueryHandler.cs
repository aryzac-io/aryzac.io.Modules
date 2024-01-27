using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Repositories;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines.GetInvoiceLines
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetInvoiceLinesQueryHandler : IRequestHandler<GetInvoiceLinesQuery, List<InvoiceLineDto>>
    {
        private readonly IInvoiceLineRepository _invoiceLineRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Merge)]
        public GetInvoiceLinesQueryHandler(IInvoiceLineRepository invoiceLineRepository, IMapper mapper)
        {
            _invoiceLineRepository = invoiceLineRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<List<InvoiceLineDto>> Handle(GetInvoiceLinesQuery request, CancellationToken cancellationToken)
        {
            var invoiceLines = await _invoiceLineRepository.FindAllAsync(cancellationToken);
            return invoiceLines.MapToInvoiceLineDtoList(_mapper);
        }
    }
}