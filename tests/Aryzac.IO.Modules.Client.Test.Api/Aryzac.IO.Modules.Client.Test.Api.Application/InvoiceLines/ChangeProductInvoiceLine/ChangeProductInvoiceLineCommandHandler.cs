using System;
using System.Threading;
using System.Threading.Tasks;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Common.Exceptions;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines.ChangeProductInvoiceLine
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class ChangeProductInvoiceLineCommandHandler : IRequestHandler<ChangeProductInvoiceLineCommand>
    {
        private readonly IInvoiceLineRepository _invoiceLineRepository;

        [IntentManaged(Mode.Merge)]
        public ChangeProductInvoiceLineCommandHandler(IInvoiceLineRepository invoiceLineRepository)
        {
            _invoiceLineRepository = invoiceLineRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task Handle(ChangeProductInvoiceLineCommand request, CancellationToken cancellationToken)
        {
            var invoiceLine = await _invoiceLineRepository.FindByIdAsync(request.Id, cancellationToken);
            if (invoiceLine is null)
            {
                throw new NotFoundException($"Could not find InvoiceLine '{request.Id}'");
            }

            invoiceLine.ChangeProduct(request.ProductId, request.UnitPrice);
        }
    }
}