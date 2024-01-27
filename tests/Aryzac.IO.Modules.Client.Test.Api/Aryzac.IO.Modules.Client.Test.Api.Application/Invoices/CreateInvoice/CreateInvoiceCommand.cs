using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Invoices.CreateInvoice
{
    public class CreateInvoiceCommand : IRequest<Guid>, ICommand
    {
        public CreateInvoiceCommand(Guid clientId, string number, DateTimeOffset dueDate)
        {
            ClientId = clientId;
            Number = number;
            DueDate = dueDate;
        }

        public Guid ClientId { get; set; }
        public string Number { get; set; }
        public DateTimeOffset DueDate { get; set; }
    }
}