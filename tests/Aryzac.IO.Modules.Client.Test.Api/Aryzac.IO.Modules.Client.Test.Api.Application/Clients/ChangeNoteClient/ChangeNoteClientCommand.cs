using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Clients.ChangeNoteClient
{
    public class ChangeNoteClientCommand : IRequest, ICommand
    {
        public ChangeNoteClientCommand(Guid id, string notes)
        {
            Id = id;
            Notes = notes;
        }

        public Guid Id { get; set; }
        public string Notes { get; set; }
    }
}