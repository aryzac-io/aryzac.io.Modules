using System;
using System.Threading;
using System.Threading.Tasks;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Common.Exceptions;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Clients.ChangeReceivePromotionClient
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class ChangeReceivePromotionClientCommandHandler : IRequestHandler<ChangeReceivePromotionClientCommand>
    {
        private readonly IClientRepository _clientRepository;

        [IntentManaged(Mode.Merge)]
        public ChangeReceivePromotionClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task Handle(ChangeReceivePromotionClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.FindByIdAsync(request.Id, cancellationToken);
            if (client is null)
            {
                throw new NotFoundException($"Could not find Client '{request.Id}'");
            }

            client.ChangeReceivePromotion(request.ReceivePromotions);
        }
    }
}