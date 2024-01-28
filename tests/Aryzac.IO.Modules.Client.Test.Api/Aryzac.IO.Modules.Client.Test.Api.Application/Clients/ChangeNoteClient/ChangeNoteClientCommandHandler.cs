using System;
using System.Threading;
using System.Threading.Tasks;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Common.Exceptions;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Clients.ChangeNoteClient
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class ChangeNoteClientCommandHandler : IRequestHandler<ChangeNoteClientCommand>
    {
        private readonly IClientRepository _clientRepository;

        [IntentManaged(Mode.Merge)]
        public ChangeNoteClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task Handle(ChangeNoteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.FindByIdAsync(request.Id, cancellationToken);
            if (client is null)
            {
                throw new NotFoundException($"Could not find Client '{request.Id}'");
            }

            client.ChangeNote(request.Notes);
        }
    }
}