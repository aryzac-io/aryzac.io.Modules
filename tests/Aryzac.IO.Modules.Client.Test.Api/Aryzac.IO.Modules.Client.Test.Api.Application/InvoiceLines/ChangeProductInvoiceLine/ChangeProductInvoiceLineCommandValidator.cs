using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines.ChangeProductInvoiceLine
{
    public class ChangeProductInvoiceLineCommandValidator : AbstractValidator<ChangeProductInvoiceLineCommand>
    {
        [IntentManaged(Mode.Merge)]
        public ChangeProductInvoiceLineCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}