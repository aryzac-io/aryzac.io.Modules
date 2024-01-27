using System;
using System.Collections.Generic;
using Aryzac.IO.Modules.Client.Test.Api.Domain.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Domain.Entities
{
    public class InvoiceLine : IHasDomainEvent
    {
        public InvoiceLine(Guid invoiceId, Guid productId, decimal quantity, decimal unitPrice, decimal discount)
        {
            InvoiceId = invoiceId;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
        }

        /// <summary>
        /// Required by Entity Framework.
        /// </summary>
        protected InvoiceLine()
        {
        }

        public Guid Id { get; private set; }

        public Guid InvoiceId { get; private set; }

        public Guid ProductId { get; private set; }

        public decimal Quantity { get; private set; } = 1;

        public decimal UnitPrice { get; private set; }

        public decimal Discount { get; private set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        public void ChangeProduct(Guid productId, decimal unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }

        public void ChangeQuentity(decimal quantity)
        {
            Quantity = quantity;
        }

        public void ChangeDiscount(decimal discount)
        {
            Discount = discount;
        }
    }
}