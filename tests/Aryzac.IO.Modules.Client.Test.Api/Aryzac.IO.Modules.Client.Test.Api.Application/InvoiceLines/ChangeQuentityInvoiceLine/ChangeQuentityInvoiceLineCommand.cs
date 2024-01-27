using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines.ChangeQuentityInvoiceLine
{
    public class ChangeQuentityInvoiceLineCommand : IRequest, ICommand
    {
        public ChangeQuentityInvoiceLineCommand(Guid id, decimal quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public Guid Id { get; set; }
        public decimal Quantity { get; set; }
    }
}