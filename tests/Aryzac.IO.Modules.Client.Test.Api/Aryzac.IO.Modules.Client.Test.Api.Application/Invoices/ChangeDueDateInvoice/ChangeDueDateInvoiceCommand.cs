using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Invoices.ChangeDueDateInvoice
{
    public class ChangeDueDateInvoiceCommand : IRequest, ICommand
    {
        public ChangeDueDateInvoiceCommand(Guid id, DateTimeOffset dueDate)
        {
            Id = id;
            DueDate = dueDate;
        }

        public Guid Id { get; set; }
        public DateTimeOffset DueDate { get; set; }
    }
}