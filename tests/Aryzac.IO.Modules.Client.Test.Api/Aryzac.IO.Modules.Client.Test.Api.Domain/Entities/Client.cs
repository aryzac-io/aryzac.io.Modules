using System;
using System.Collections.Generic;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Domain.Entities
{
    public class Client : IHasDomainEvent
    {
        public Client(string firstName, string lastName, string? otherNames)
        {
            FirstName = firstName;
            LastName = lastName;
            OtherNames = otherNames;
        }

        /// <summary>
        /// Required by Entity Framework.
        /// </summary>
        protected Client()
        {
            FirstName = null!;
            LastName = null!;
        }

        public Guid Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string? OtherNames { get; private set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        public void ChangeName(string firstName, string lastName, string? otherNames)
        {
            FirstName = firstName;
            LastName = lastName;
            OtherNames = otherNames;
        }
    }
}