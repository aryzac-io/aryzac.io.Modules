using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Clients.ChangeTitleClient
{
    public class ChangeTitleClientCommand : IRequest, ICommand
    {
        public ChangeTitleClientCommand(Guid id, Guid titleId)
        {
            Id = id;
            TitleId = titleId;
        }

        public Guid Id { get; set; }
        public Guid TitleId { get; set; }
    }
}