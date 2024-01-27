using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines.ChangeProductInvoiceLine
{
    public class ChangeProductInvoiceLineCommand : IRequest, ICommand
    {
        public ChangeProductInvoiceLineCommand(Guid id, Guid productId, decimal unitPrice)
        {
            Id = id;
            ProductId = productId;
            UnitPrice = unitPrice;
        }

        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
    }
}