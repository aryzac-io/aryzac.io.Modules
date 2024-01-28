using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Clients.ChangeReceivePromotionClient
{
    public class ChangeReceivePromotionClientCommand : IRequest, ICommand
    {
        public ChangeReceivePromotionClientCommand(Guid id, bool receivePromotions)
        {
            Id = id;
            ReceivePromotions = receivePromotions;
        }

        public Guid Id { get; set; }
        public bool ReceivePromotions { get; set; }
    }
}