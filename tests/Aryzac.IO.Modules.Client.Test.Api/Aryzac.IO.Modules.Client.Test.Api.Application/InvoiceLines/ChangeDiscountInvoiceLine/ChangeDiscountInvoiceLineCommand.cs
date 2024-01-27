using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines.ChangeDiscountInvoiceLine
{
    public class ChangeDiscountInvoiceLineCommand : IRequest, ICommand
    {
        public ChangeDiscountInvoiceLineCommand(Guid id, decimal discount)
        {
            Id = id;
            Discount = discount;
        }

        public Guid Id { get; set; }
        public decimal Discount { get; set; }
    }
}