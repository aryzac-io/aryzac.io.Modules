using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Mappings;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Entities;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Titles
{
    public class TitleDto : IMapFrom<Title>
    {
        public TitleDto()
        {
            Code = null!;
            Name = null!;
            Description = null!;
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static TitleDto Create(Guid id, string code, string name, string description)
        {
            return new TitleDto
            {
                Id = id,
                Code = code,
                Name = name,
                Description = description
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Title, TitleDto>();
        }
    }
}