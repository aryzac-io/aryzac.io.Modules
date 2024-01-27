using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Titles.ChangeCodeTitle
{
    public class ChangeCodeTitleCommandValidator : AbstractValidator<ChangeCodeTitleCommand>
    {
        [IntentManaged(Mode.Merge)]
        public ChangeCodeTitleCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Code)
                .NotNull();
        }
    }
}