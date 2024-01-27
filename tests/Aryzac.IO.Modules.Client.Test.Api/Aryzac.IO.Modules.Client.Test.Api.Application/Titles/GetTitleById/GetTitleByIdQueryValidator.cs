using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.QueryValidator", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Titles.GetTitleById
{
    public class GetTitleByIdQueryValidator : AbstractValidator<GetTitleByIdQuery>
    {
        [IntentManaged(Mode.Merge)]
        public GetTitleByIdQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}