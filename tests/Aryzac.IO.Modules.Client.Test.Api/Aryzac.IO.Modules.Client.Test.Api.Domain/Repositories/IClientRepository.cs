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
    public interface IClientRepository : IEFRepository<Api.Domain.Entities.Client, Api.Domain.Entities.Client>
    {
        [IntentManaged(Mode.Fully)]
        Task<Api.Domain.Entities.Client?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<Api.Domain.Entities.Client>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default);
    }
}