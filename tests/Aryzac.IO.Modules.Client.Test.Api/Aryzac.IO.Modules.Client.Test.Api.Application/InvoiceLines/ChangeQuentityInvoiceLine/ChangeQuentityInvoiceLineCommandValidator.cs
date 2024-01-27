using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines.ChangeQuentityInvoiceLine
{
    public class ChangeQuentityInvoiceLineCommandValidator : AbstractValidator<ChangeQuentityInvoiceLineCommand>
    {
        [IntentManaged(Mode.Merge)]
        public ChangeQuentityInvoiceLineCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}