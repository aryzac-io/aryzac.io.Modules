using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines.CreateInvoiceLine
{
    public class CreateInvoiceLineCommandValidator : AbstractValidator<CreateInvoiceLineCommand>
    {
        [IntentManaged(Mode.Merge)]
        public CreateInvoiceLineCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}