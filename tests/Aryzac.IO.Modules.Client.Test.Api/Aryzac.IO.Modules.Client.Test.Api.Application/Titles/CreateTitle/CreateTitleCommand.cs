using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Titles.CreateTitle
{
    public class CreateTitleCommand : IRequest<Guid>, ICommand
    {
        public CreateTitleCommand(string code, string name, string description)
        {
            Code = code;
            Name = name;
            Description = description;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}