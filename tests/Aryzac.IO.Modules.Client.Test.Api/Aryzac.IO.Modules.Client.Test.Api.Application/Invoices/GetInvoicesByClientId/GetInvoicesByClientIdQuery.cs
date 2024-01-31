using System;
using System.Collections.Generic;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Invoices.GetInvoicesByClientId
{
    public class GetInvoicesByClientIdQuery : IRequest<List<InvoiceDto>>, IQuery
    {
        public GetInvoicesByClientIdQuery(Guid clientId)
        {
            ClientId = clientId;
        }

        public Guid ClientId { get; set; }
    }
}