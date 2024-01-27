using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Titles.ChangeCodeTitle
{
    public class ChangeCodeTitleCommand : IRequest, ICommand
    {
        public ChangeCodeTitleCommand(Guid id, string code)
        {
            Id = id;
            Code = code;
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
    }
}