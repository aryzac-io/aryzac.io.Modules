using System.Collections.Generic;
using System.Linq;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Entities;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Titles
{
    public static class TitleDtoMappingExtensions
    {
        public static TitleDto MapToTitleDto(this Title projectFrom, IMapper mapper)
            => mapper.Map<TitleDto>(projectFrom);

        public static List<TitleDto> MapToTitleDtoList(this IEnumerable<Title> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToTitleDto(mapper)).ToList();
    }
}