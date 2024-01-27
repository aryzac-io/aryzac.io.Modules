using System.Collections.Generic;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines.GetInvoiceLines
{
    public class GetInvoiceLinesQuery : IRequest<List<InvoiceLineDto>>, IQuery
    {
        public GetInvoiceLinesQuery()
        {
        }
    }
}