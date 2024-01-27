using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines.GetInvoiceLineById
{
    public class GetInvoiceLineByIdQuery : IRequest<InvoiceLineDto>, IQuery
    {
        public GetInvoiceLineByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}