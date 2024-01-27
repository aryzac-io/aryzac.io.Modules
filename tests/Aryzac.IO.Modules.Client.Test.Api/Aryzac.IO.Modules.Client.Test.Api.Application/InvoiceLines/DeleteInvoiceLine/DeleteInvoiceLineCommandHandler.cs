using System;
using System.Threading;
using System.Threading.Tasks;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Common.Exceptions;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines.DeleteInvoiceLine
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteInvoiceLineCommandHandler : IRequestHandler<DeleteInvoiceLineCommand>
    {
        private readonly IInvoiceLineRepository _invoiceLineRepository;

        [IntentManaged(Mode.Merge)]
        public DeleteInvoiceLineCommandHandler(IInvoiceLineRepository invoiceLineRepository)
        {
            _invoiceLineRepository = invoiceLineRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task Handle(DeleteInvoiceLineCommand request, CancellationToken cancellationToken)
        {
            var invoiceLine = await _invoiceLineRepository.FindByIdAsync(request.Id, cancellationToken);
            if (invoiceLine is null)
            {
                throw new NotFoundException($"Could not find InvoiceLine '{request.Id}'");
            }

            _invoiceLineRepository.Remove(invoiceLine);
        }
    }
}