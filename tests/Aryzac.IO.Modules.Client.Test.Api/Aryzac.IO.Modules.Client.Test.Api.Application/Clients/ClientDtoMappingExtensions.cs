using System.Collections.Generic;
using System.Linq;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Entities;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Clients
{
    public static class ClientDtoMappingExtensions
    {
        public static ClientDto MapToClientDto(this Api.Domain.Entities.Client projectFrom, IMapper mapper)
            => mapper.Map<ClientDto>(projectFrom);

        public static List<ClientDto> MapToClientDtoList(this IEnumerable<Api.Domain.Entities.Client> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToClientDto(mapper)).ToList();
    }
}