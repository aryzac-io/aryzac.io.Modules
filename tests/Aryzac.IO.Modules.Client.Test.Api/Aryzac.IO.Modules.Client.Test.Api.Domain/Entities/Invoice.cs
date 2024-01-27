using System;
using System.Collections.Generic;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Domain.Entities
{
    public class Invoice : IHasDomainEvent
    {
        public Invoice(Guid clientId, string number, DateTimeOffset dueDate)
        {
            ClientId = clientId;
            Number = number;
            DueDate = dueDate;
        }

        /// <summary>
        /// Required by Entity Framework.
        /// </summary>
        protected Invoice()
        {
            Number = null!;
        }

        public Guid Id { get; private set; }

        public Guid ClientId { get; private set; }

        public string Number { get; private set; }

        public DateTimeOffset CreatedDate { get; private set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset DueDate { get; private set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        public void ChangeDueDate(DateTimeOffset dueDate)
        {
            DueDate = dueDate;
        }
    }
}