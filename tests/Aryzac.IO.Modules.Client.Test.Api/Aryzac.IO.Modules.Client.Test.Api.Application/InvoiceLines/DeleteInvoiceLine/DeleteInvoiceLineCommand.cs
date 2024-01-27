using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines.DeleteInvoiceLine
{
    public class DeleteInvoiceLineCommand : IRequest, ICommand
    {
        public DeleteInvoiceLineCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}