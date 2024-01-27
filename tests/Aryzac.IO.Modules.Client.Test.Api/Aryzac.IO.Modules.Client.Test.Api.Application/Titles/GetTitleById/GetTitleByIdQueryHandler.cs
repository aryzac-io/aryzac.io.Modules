using System;
using System.Threading;
using System.Threading.Tasks;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Common.Exceptions;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Repositories;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Titles.GetTitleById
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetTitleByIdQueryHandler : IRequestHandler<GetTitleByIdQuery, TitleDto>
    {
        private readonly ITitleRepository _titleRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Merge)]
        public GetTitleByIdQueryHandler(ITitleRepository titleRepository, IMapper mapper)
        {
            _titleRepository = titleRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<TitleDto> Handle(GetTitleByIdQuery request, CancellationToken cancellationToken)
        {
            var title = await _titleRepository.FindByIdAsync(request.Id, cancellationToken);
            if (title is null)
            {
                throw new NotFoundException($"Could not find Title '{request.Id}'");
            }
            return title.MapToTitleDto(_mapper);
        }
    }
}