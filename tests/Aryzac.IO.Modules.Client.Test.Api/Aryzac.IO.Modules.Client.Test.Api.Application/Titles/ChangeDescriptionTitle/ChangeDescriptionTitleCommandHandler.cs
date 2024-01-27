using System;
using System.Threading;
using System.Threading.Tasks;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Common.Exceptions;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Titles.ChangeDescriptionTitle
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class ChangeDescriptionTitleCommandHandler : IRequestHandler<ChangeDescriptionTitleCommand>
    {
        private readonly ITitleRepository _titleRepository;

        [IntentManaged(Mode.Merge)]
        public ChangeDescriptionTitleCommandHandler(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task Handle(ChangeDescriptionTitleCommand request, CancellationToken cancellationToken)
        {
            var title = await _titleRepository.FindByIdAsync(request.Id, cancellationToken);
            if (title is null)
            {
                throw new NotFoundException($"Could not find Title '{request.Id}'");
            }

            title.ChangeDescription(request.Description);
        }
    }
}