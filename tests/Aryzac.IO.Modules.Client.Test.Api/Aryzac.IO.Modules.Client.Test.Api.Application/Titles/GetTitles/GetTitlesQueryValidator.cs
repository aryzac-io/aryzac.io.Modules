using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.QueryValidator", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Titles.GetTitles
{
    public class GetTitlesQueryValidator : AbstractValidator<GetTitlesQuery>
    {
        [IntentManaged(Mode.Merge)]
        public GetTitlesQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}