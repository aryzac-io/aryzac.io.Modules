using System;
using System.Threading;
using System.Threading.Tasks;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Common.Exceptions;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Repositories;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines.GetInvoiceLineById
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetInvoiceLineByIdQueryHandler : IRequestHandler<GetInvoiceLineByIdQuery, InvoiceLineDto>
    {
        private readonly IInvoiceLineRepository _invoiceLineRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Merge)]
        public GetInvoiceLineByIdQueryHandler(IInvoiceLineRepository invoiceLineRepository, IMapper mapper)
        {
            _invoiceLineRepository = invoiceLineRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<InvoiceLineDto> Handle(GetInvoiceLineByIdQuery request, CancellationToken cancellationToken)
        {
            var invoiceLine = await _invoiceLineRepository.FindByIdAsync(request.Id, cancellationToken);
            if (invoiceLine is null)
            {
                throw new NotFoundException($"Could not find InvoiceLine '{request.Id}'");
            }
            return invoiceLine.MapToInvoiceLineDto(_mapper);
        }
    }
}