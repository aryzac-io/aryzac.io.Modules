using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.QueryValidator", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.InvoiceLines.GetInvoiceLineById
{
    public class GetInvoiceLineByIdQueryValidator : AbstractValidator<GetInvoiceLineByIdQuery>
    {
        [IntentManaged(Mode.Merge)]
        public GetInvoiceLineByIdQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}