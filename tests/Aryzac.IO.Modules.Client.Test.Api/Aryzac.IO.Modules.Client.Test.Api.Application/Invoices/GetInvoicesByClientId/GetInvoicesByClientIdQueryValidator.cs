using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.QueryValidator", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Invoices.GetInvoicesByClientId
{
    public class GetInvoicesByClientIdQueryValidator : AbstractValidator<GetInvoicesByClientIdQuery>
    {
        [IntentManaged(Mode.Merge)]
        public GetInvoicesByClientIdQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}