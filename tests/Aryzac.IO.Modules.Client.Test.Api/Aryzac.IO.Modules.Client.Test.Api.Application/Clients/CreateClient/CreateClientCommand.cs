using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Clients.CreateClient
{
    public class CreateClientCommand : IRequest<Guid>, ICommand
    {
        public CreateClientCommand(string firstName, string lastName, string? otherNames, string newDTOField)
        {
            FirstName = firstName;
            LastName = lastName;
            OtherNames = otherNames;
            NewDTOField = newDTOField;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? OtherNames { get; set; }
        public string NewDTOField { get; set; }
    }
}