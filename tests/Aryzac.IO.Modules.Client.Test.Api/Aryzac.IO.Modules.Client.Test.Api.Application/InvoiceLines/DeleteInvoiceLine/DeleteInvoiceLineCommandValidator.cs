using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines.DeleteInvoiceLine
{
    public class DeleteInvoiceLineCommandValidator : AbstractValidator<DeleteInvoiceLineCommand>
    {
        [IntentManaged(Mode.Merge)]
        public DeleteInvoiceLineCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}