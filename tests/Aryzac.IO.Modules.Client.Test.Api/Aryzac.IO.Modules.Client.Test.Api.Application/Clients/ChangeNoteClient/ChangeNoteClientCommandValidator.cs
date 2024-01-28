using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Clients.ChangeNoteClient
{
    public class ChangeNoteClientCommandValidator : AbstractValidator<ChangeNoteClientCommand>
    {
        [IntentManaged(Mode.Merge)]
        public ChangeNoteClientCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Notes)
                .NotNull();
        }
    }
}