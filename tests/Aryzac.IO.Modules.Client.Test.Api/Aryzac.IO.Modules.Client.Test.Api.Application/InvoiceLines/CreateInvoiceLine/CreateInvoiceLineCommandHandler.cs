using System;
using System.Threading;
using System.Threading.Tasks;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Entities;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines.CreateInvoiceLine
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateInvoiceLineCommandHandler : IRequestHandler<CreateInvoiceLineCommand, Guid>
    {
        private readonly IInvoiceLineRepository _invoiceLineRepository;

        [IntentManaged(Mode.Merge)]
        public CreateInvoiceLineCommandHandler(IInvoiceLineRepository invoiceLineRepository)
        {
            _invoiceLineRepository = invoiceLineRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Guid> Handle(CreateInvoiceLineCommand request, CancellationToken cancellationToken)
        {
            var invoiceLine = new InvoiceLine(
                invoiceId: request.InvoiceId,
                productId: request.ProductId,
                quantity: request.Quantity,
                unitPrice: request.UnitPrice,
                discount: request.Discount);

            _invoiceLineRepository.Add(invoiceLine);
            await _invoiceLineRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return invoiceLine.Id;
        }
    }
}