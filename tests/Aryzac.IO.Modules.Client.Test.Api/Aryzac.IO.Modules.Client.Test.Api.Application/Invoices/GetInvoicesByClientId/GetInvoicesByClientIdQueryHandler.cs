using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Common.Exceptions;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Repositories;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Invoices.GetInvoicesByClientId
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetInvoicesByClientIdQueryHandler : IRequestHandler<GetInvoicesByClientIdQuery, List<InvoiceDto>>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Merge)]
        public GetInvoicesByClientIdQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<List<InvoiceDto>> Handle(GetInvoicesByClientIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _invoiceRepository.FindAllAsync(x => x.ClientId == request.ClientId, cancellationToken);
            return entity.MapToInvoiceDtoList(_mapper);
        }
    }
}