using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "2.0")]

namespace Aryzac.IO.Modules.Client.Test.Api.Application.Clients.ChangeReceivePromotionClient
{
    public class ChangeReceivePromotionClientCommandValidator : AbstractValidator<ChangeReceivePromotionClientCommand>
    {
        [IntentManaged(Mode.Merge)]
        public ChangeReceivePromotionClientCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}