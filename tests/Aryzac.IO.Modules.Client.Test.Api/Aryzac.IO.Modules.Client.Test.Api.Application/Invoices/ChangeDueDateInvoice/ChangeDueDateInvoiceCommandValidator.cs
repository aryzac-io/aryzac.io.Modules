using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Invoices.ChangeDueDateInvoice
{
    public class ChangeDueDateInvoiceCommandValidator : AbstractValidator<ChangeDueDateInvoiceCommand>
    {
        [IntentManaged(Mode.Merge)]
        public ChangeDueDateInvoiceCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}