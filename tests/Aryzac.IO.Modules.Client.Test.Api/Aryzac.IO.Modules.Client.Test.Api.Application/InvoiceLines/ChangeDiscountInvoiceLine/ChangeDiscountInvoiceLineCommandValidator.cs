using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines.ChangeDiscountInvoiceLine
{
    public class ChangeDiscountInvoiceLineCommandValidator : AbstractValidator<ChangeDiscountInvoiceLineCommand>
    {
        [IntentManaged(Mode.Merge)]
        public ChangeDiscountInvoiceLineCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}