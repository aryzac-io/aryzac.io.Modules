using System;
using System.Collections.Generic;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Domain.Entities
{
    public class Title : IHasDomainEvent
    {
        public Title(string code, string name, string description)
        {
            Code = code;
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Required by Entity Framework.
        /// </summary>
        protected Title()
        {
            Code = null!;
            Name = null!;
            Description = null!;
        }

        public Guid Id { get; private set; }

        public string Code { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        public void ChangeCode(string code)
        {
            Code = code;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangeDescription(string description)
        {
            Description = description;
        }
    }
}