using System;
using Aryzac.IO.Modules.Client.Test.Api.Application.Common.Mappings;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Entities;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Clients
{
    public class ClientDto : IMapFrom<Api.Domain.Entities.Client>
    {
        public ClientDto()
        {
            FirstName = null!;
            LastName = null!;
            Notes = null!;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? OtherNames { get; set; }
        public Guid TitleId { get; set; }
        public bool ReceivePromotions { get; set; }
        public string Notes { get; set; }

        public static ClientDto Create(
            Guid id,
            string firstName,
            string lastName,
            string? otherNames,
            Guid titleId,
            bool receivePromotions,
            string notes)
        {
            return new ClientDto
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                OtherNames = otherNames,
                TitleId = titleId,
                ReceivePromotions = receivePromotions,
                Notes = notes
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Api.Domain.Entities.Client, ClientDto>();
        }
    }
}