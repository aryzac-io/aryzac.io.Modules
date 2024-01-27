using System;
using System.Threading;
using System.Threading.Tasks;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Entities;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Titles.CreateTitle
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateTitleCommandHandler : IRequestHandler<CreateTitleCommand, Guid>
    {
        private readonly ITitleRepository _titleRepository;

        [IntentManaged(Mode.Merge)]
        public CreateTitleCommandHandler(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Guid> Handle(CreateTitleCommand request, CancellationToken cancellationToken)
        {
            var title = new Title(
                code: request.Code,
                name: request.Name,
                description: request.Description);

            _titleRepository.Add(title);
            await _titleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return title.Id;
        }
    }
}