using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Clients.ChangeNameClient
{
    public class ChangeNameClientCommand : IRequest, ICommand
    {
        public ChangeNameClientCommand(Guid id, string firstName, string lastName, string? otherNames)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            OtherNames = otherNames;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? OtherNames { get; set; }
    }
}