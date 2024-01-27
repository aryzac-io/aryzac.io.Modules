using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Domain.Repositories
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public interface IInvoiceLineRepository : IEFRepository<InvoiceLine, InvoiceLine>
    {
        [IntentManaged(Mode.Fully)]
        Task<InvoiceLine?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<InvoiceLine>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default);
    }
}